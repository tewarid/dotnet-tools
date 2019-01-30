using LibGit2Sharp;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitTool
{
    public partial class MainForm : Form
    {
        RemoteBrowser browser = new RemoteBrowser();

        private readonly string VARIABLE_START = "{{";
        private readonly string VARIABLE_END = "}}";
        private readonly string VARIABLE_OUT = "OUT";
        private readonly string REMOTE_PATH_SEPARATOR = "/";

        private ConcurrentDictionary<string, string> context =
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
                if (line.StartsWith("$ "))
                {
                    cheats.Items.Add(line.Substring(6)); // skip "$ git "
                }
            }
        }

        private void scan_Click(object sender, EventArgs e)
        {
            Scan(rootFolder.Text);
        }

        private void Scan(string folder)
        {
            if (Directory.Exists(folder))
            {
                gitFolders.Items.Clear();
                scan.Enabled = false;
                browse.Enabled = false;
                Task.Run(() =>
                {
                    Scan(new DirectoryInfo(folder));
                }).ContinueWith((task) => {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        scan.Enabled = true;
                        browse.Enabled = true;
                    }));
                });
            }
            else
            {
                MessageBox.Show(this, $"Folder {folder} not found.");
            }
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

        private void clipboard_Click(object sender, EventArgs e)
        {
            IList list = GetFolders();
            string[] folders = new string[list.Count];
            list.CopyTo(folders, 0);
            Clipboard.SetText(String.Join(Environment.NewLine, folders));
        }

        private void browse_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = rootFolder.Text;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                rootFolder.Text = folderBrowser.SelectedPath;
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            string [] gitCommands = command.Text.Split(new [] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            
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

        private string ProcessVariables(string cmd, IDictionary<string, string> context)
        {
            if (!cmd.Contains(VARIABLE_START))
            {
                return cmd;
            }
            int index = 0;
            int startIndex = 0;
            string cmdReturn = string.Empty;
            while ((startIndex = cmd.IndexOf(VARIABLE_START, index)) != -1)
            {
                cmdReturn += cmd.Substring(index, startIndex - index);
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
                    cmdReturn += ProcessVariable(variable, context);
                }
                catch
                {
                    // ignore exception
                }
                index = endIndex + VARIABLE_END.Length;
            }
            cmdReturn += cmd.Substring(index, cmd.Length - index);
            return cmdReturn;
        }

        private string ProcessVariable(string variable, IDictionary<string, string> context)
        {
            variable = variable.Trim();
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
            proc.Start();
            string output = string.Empty;
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (line == null)
                {
                    break;
                }
                output += line + Environment.NewLine;
                log.AppendText(line + Environment.NewLine);
            }
            log.AppendText(proc.StandardError.ReadToEnd().Replace("\n",
                Environment.NewLine).Replace("\r", Environment.NewLine));
            log.AppendText(Environment.NewLine);
            return output;
        }

        private void rootFolder_TextChanged(object sender, EventArgs e)
        {
            Scan(rootFolder.Text);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            log.Clear();
        }

        private void clone_Click(object sender, EventArgs e)
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

        private void cheats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!command.Text.EndsWith(Environment.NewLine))
            {
                command.AppendText(Environment.NewLine);
            }
            string gitcmd = (string)cheats.SelectedItem;
            command.AppendText(gitcmd);
        }
    }
}
