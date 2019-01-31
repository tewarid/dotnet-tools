using GitLabApiClient;
using Octokit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitTool
{
    public partial class RemoteBrowser : Form
    {
        public DialogResult Result { get; private set; }
        public string [] Repositories { get; private set; }

        public RemoteBrowser()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            this.Visible = false;
        }

        private async void query_Click(object sender, EventArgs e)
        {
            query.Enabled = false;
            try
            {
                if (gitHub.Checked)
                {
                    await QueryGitHub().ConfigureAwait(true);
                }
                else
                {
                    await QueryGitLab().ConfigureAwait(true);
                }
            }
            catch
            {
                MessageBox.Show(this, "Query failed. Username is optional for GitLab but required for GitHub. Password or token is required to list your projects.");
            }
            query.Enabled = true;
        }

        private async Task QueryGitLab()
        {
            GitLabClient client;
            if (string.IsNullOrEmpty(username.Text))
            {
                client = new GitLabClient(host.Text, password.Text);
            }
            else
            {
                client = new GitLabClient(host.Text);
                var session = await client.LoginAsync(username.Text, password.Text);
            }
            var list = await client.Projects.GetAsync();
            repositories.Items.Clear();
            foreach (var project in list)
            {
                if (ssh.Checked)
                {
                    repositories.Items.Add(project.SshUrlToRepo);
                }
                else
                {
                    repositories.Items.Add(project.HttpUrlToRepo);
                }
            }
        }

        private async Task QueryGitHub()
        {
            var phv = new ProductHeaderValue(username.Text);
            GitHubClient client = new GitHubClient(phv, new Uri(host.Text));
            IReadOnlyList<Repository> list;
            Credentials credentials = new Credentials(username.Text, password.Text);
            client.Credentials = credentials;
            list = await client.Repository.GetAllForCurrent().ConfigureAwait(true);
            repositories.Items.Clear();
            foreach (var repo in list)
            {
                if (ssh.Checked)
                {
                    repositories.Items.Add(repo.SshUrl);
                }
                else
                {
                    repositories.Items.Add(repo.CloneUrl);
                }
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (repositories.SelectedItems.Count == 0)
            {
                return;
            }
            string[] list = new string[repositories.SelectedItems.Count];
            repositories.SelectedItems.CopyTo(list, 0);
            Result = DialogResult.OK;
            Repositories = list;
            this.Visible = false;
        }

        private void clipboard_Click(object sender, EventArgs e)
        {
            string[] list = new string[repositories.SelectedItems.Count];
            repositories.SelectedItems.CopyTo(list, 0);
            Clipboard.SetText(String.Join(Environment.NewLine, list));
        }

        private void RemoteBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Result = DialogResult.Cancel;
            }
            Properties.Settings.Default.Save();
        }

        private void gitHub_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
            {
                ((RadioButton)sender).Checked = true;
            }
        }

        private void gitLab_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
            {
                ((RadioButton)sender).Checked = true;
            }
        }

        private void ssh_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
            {
                ((RadioButton)sender).Checked = true;
            }
        }

        private void https_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
            {
                ((RadioButton)sender).Checked = true;
            }
        }
    }
}
