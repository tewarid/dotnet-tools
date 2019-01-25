using LibGit2Sharp;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void scan_Click(object sender, System.EventArgs e)
        {
            Scan(rootFolder.Text);
        }

        private void Scan(string folder)
        {
            if (Directory.Exists(folder))
            {
                gitFolders.Items.Clear();
                scan.Enabled = false;
                Task.Run(() =>
                {
                    Scan(new DirectoryInfo(folder));
                }).ContinueWith((task) => {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        scan.Enabled = true;
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
                Scan(rootFolder.Text);
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            log.Clear();
            string [] gitCommands = command.Text.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string folder in GetFolders())
            {
                foreach(string cmd in gitCommands)
                {
                    RunGitCommand(folder, cmd);
                }
            }
        }

        private void RunGitCommand(string gitFolder, string command)
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
            proc.OutputDataReceived += new DataReceivedEventHandler((dataSender, dataEvent) =>
            {
                log.AppendText(dataEvent.Data);
            });
            proc.Start();
            proc.WaitForExit();
            log.AppendText(ReplaceNewLine(proc.StandardError.ReadToEnd()));
            log.AppendText(ReplaceNewLine(proc.StandardOutput.ReadToEnd()));
            log.AppendText(Environment.NewLine);
        }

        private static string ReplaceNewLine(string old)
        {
            return old.Replace("\n", Environment.NewLine);
        }

        private void rootFolder_Leave(object sender, EventArgs e)
        {
            Scan(rootFolder.Text);
        }
    }
}
