using LibGit2Sharp;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitTool
{
    public partial class MainForm : Form
    {
        private readonly RemoteBrowser browser = new RemoteBrowser();

        private static readonly string VARIABLE_START = "{{";
        private static readonly string VARIABLE_END = "}}";
        private static readonly string VARIABLE_OUT = "OUT";
        private readonly string REMOTE_PATH_SEPARATOR = "/";
        private readonly string CHEATSHEET_COMMAND_START = "$ git ";

        private readonly ConcurrentDictionary<string, string> context =
            new ConcurrentDictionary<string, string>();

        public MainForm()
        {
            InitializeComponent();
            PopulateCheats();
        }

        private void PopulateCheats()
        {
            string[] lines = File.ReadAllLines("cheatsheet.md");
            foreach(string line in lines)
            {
                if (line.StartsWith(CHEATSHEET_COMMAND_START))
                {
                    cheats.Items.Add(line.Substring(CHEATSHEET_COMMAND_START.Length));
                }
            }
        }

        private void Scan_Click(object sender, EventArgs e)
        {
            Scan(rootFolder.Text);
        }

        private void Scan(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }
            gitFolders.Items.Clear();
            scan.Enabled = false;
            browse.Enabled = false;
            rootFolder.ReadOnly = true;
            Task.Run(() =>
            {
                Scan(new DirectoryInfo(folder));
            }).ContinueWith((task) => {
                BeginInvoke(new MethodInvoker(() =>
                {
                    if (gitFolders.Items.Contains(gitFolders.Tag))
                    {
                        gitFolders.SelectedIndex = gitFolders.Items.IndexOf(gitFolders.Tag);
                    }
                    scan.Enabled = true;
                    browse.Enabled = true;
                    rootFolder.ReadOnly = false;
                }));
            });
        }

        private void Scan(DirectoryInfo rootDir)
        {
            if (rootDir.Name.Equals(".git"))
            {
                return;
            }
            else if (Repository.IsValid(rootDir.FullName))
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    gitFolders.Items.Add(rootDir.FullName);
                }));
                return;
            }
            DirectoryInfo[] subDirs = rootDir.GetDirectories();
            foreach (DirectoryInfo dir in subDirs)
            {
                 Scan(dir);
            }
        }

        private IList GetFolders()
        {
            IList list = gitFolders.Items;
            if (gitFolders.SelectedItems.Count > 0)
            {
                list = gitFolders.SelectedItems;
            }
            return list;
        }

        private void Clipboard_Click(object sender, EventArgs e)
        {
            IList list = GetFolders();
            string[] folders = new string[list.Count];
            list.CopyTo(folders, 0);
            Clipboard.SetText(String.Join(Environment.NewLine, folders));
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = rootFolder.Text;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                rootFolder.Text = folderBrowser.SelectedPath;
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            string[] gitCommands;
            if (!string.IsNullOrWhiteSpace(command.SelectedText))
            {
                gitCommands = command.SelectedText.Split(new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);

            }
            else
            {
                gitCommands = command.Text.Split(new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);

            }

            foreach (string folder in GetFolders())
            {
                foreach(string cmd in gitCommands)
                {
                    string cmdRun = ProcessVariables(cmd, context);
                    string output = RunGitCommand(folder, cmdRun);
                    context.AddOrUpdate(VARIABLE_OUT, output, (key, oldValue) =>
                    {
                        return output;
                    });
                }
            }
        }

        private static string ProcessVariables(string cmd, IDictionary<string, string> context)
        {
            if (!cmd.Contains(VARIABLE_START))
            {
                return cmd;
            }
            int index = 0;
            int startIndex = 0;
            StringBuilder cmdResult = new StringBuilder();
            while ((startIndex = cmd.IndexOf(VARIABLE_START, index)) != -1)
            {
                cmdResult.Append(cmd.Substring(index, startIndex - index));
                int endIndex = cmd.IndexOf(VARIABLE_END);
                if (endIndex == -1)
                {
                    index = cmd.Length;
                    break;
                }
                string variable = cmd.Substring(startIndex + VARIABLE_START.Length,
                    endIndex - (startIndex + VARIABLE_START.Length));
                try
                {
                    cmdResult.Append(ProcessVariable(variable.Trim(), context));
                }
                catch
                {
                    // ignore exception
                }
                index = endIndex + VARIABLE_END.Length;
            }
            cmdResult.Append(cmd.Substring(index, cmd.Length - index));
            return cmdResult.ToString();
        }

        private static string ProcessVariable(string variable, IDictionary<string, string> context)
        {
            string name = variable;
            int startIndex = 0;
            int length = 0;
            int colonIndex = variable.IndexOf(":");
            if (colonIndex != -1)
            {
                name = variable.Substring(0, colonIndex);
                int commaIndex = variable.IndexOf(",", colonIndex);
                if (commaIndex != -1)
                {
                    startIndex = int.Parse(variable.Substring(colonIndex + 1,
                        commaIndex - (colonIndex + 1)));
                    length = int.Parse(variable.Substring(commaIndex + 1,
                        variable.Length - (commaIndex + 1)));
                }
            }
            string value = string.Empty;
            if (context.ContainsKey(name))
            {
                value = context[name];
            }
            if (length == 0)
            {
                length = value.Length - startIndex - 1;
            }
            return value.Substring(startIndex, length);
        }

        private string RunGitCommand(string gitFolder, string command)
        {
            log.AppendText($"{gitFolder}> git {command}{Environment.NewLine}");
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = gitFolder
            };
            Process proc = new Process();
            proc.StartInfo = info;
            string error = string.Empty;
            proc.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    error += e.Data + Environment.NewLine;
                }
            };
            string output = string.Empty;
            proc.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    output += e.Data + Environment.NewLine;
                }
            };
            try
            {
                proc.Start();
            }
            catch (Exception ex)
            {
                log.AppendText(ex.Message);
                log.AppendText(Environment.NewLine);
                log.AppendText(Environment.NewLine);
                return string.Empty;
            }
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();
            log.AppendText(error);
            log.AppendText(output);
            log.AppendText(Environment.NewLine);
            return output;
        }

        private void RootFolder_TextChanged(object sender, EventArgs e)
        {
            Scan(rootFolder.Text);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            log.Clear();
        }

        private void Clone_Click(object sender, EventArgs e)
        {
            browser.ShowDialog(this);
            if (browser.Result == DialogResult.OK)
            {
                foreach(var repo in browser.Repositories)
                {
                    int colonStartIndex = repo.LastIndexOf(":");
                    string path = rootFolder.Text;
                    if (colonStartIndex != -1)
                    {
                        string remotePath = repo.Substring(colonStartIndex + 1);
                        string[] remotePaths = remotePath.Split(new[] { REMOTE_PATH_SEPARATOR },
                            StringSplitOptions.RemoveEmptyEntries);
                        path = string.Join(Path.DirectorySeparatorChar.ToString(),
                            remotePaths, 0, remotePaths.Length - 1);
                        path = Path.Combine(rootFolder.Text, path);
                        Directory.CreateDirectory(path);
                    }
                    RunGitCommand(path, $"clone {repo}");
                }
            }
        }

        private void Cheats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!command.Text.EndsWith(Environment.NewLine))
            {
                command.AppendText(Environment.NewLine);
            }
            string gitcmd = (string)cheats.SelectedItem;
            command.AppendText(gitcmd);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Scan(rootFolder.Text);
        }

        private void Explore_Click(object sender, EventArgs e)
        {
            if (gitFolders.SelectedItem != null)
            {
                Process.Start((string)gitFolders.SelectedItem);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            log.SelectionStart = log.TextLength;
            log.ScrollToCaret();
        }

        private void GitFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            gitFolders.Tag = gitFolders.Items[gitFolders.SelectedIndex];
        }
    }
}
