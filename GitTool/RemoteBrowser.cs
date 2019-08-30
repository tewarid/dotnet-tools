using GitLabApiClient;
using Octokit;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            if (gitHub.Checked)
            {
                await QueryGitHub().ConfigureAwait(true);
            }
            else
            {
                await QueryGitLab().ConfigureAwait(true);
            }
            query.Enabled = true;
        }

        private string GetOrSetHost(string defaultValue)
        {
            if (string.IsNullOrWhiteSpace(host.Text))
            {
                host.Text = defaultValue;
                return defaultValue;
            }
            return host.Text;
        }

        private async Task QueryGitLab()
        {
            string baseUrl = GetOrSetHost("https://gitlab.com");
            GitLabClient client;
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Please specify password or access token.");
                return;
            }
            if (string.IsNullOrEmpty(username.Text))
            {
                client = new GitLabClient(baseUrl, password.Text);
            }
            else
            {
                client = new GitLabClient(baseUrl);
                try
                {
                    var session = await client.LoginAsync(username.Text, password.Text);
                }
                catch (GitLabException ex)
                {
                    MessageBox.Show("Login failed.");
                    return;
                }
            }
            IList<GitLabApiClient.Models.Projects.Responses.Project> list;
            try
            {
                list = await client.Projects.GetAsync();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Failed to query GitLab instance at {baseUrl}.");
                return;
            }
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
            string baseUrl = GetOrSetHost("https://github.com");
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                MessageBox.Show("Please specify username.");
                return;
            }
            var phv = new ProductHeaderValue(username.Text);
            GitHubClient client = new GitHubClient(phv, new Uri(baseUrl));
            IReadOnlyList<Repository> list;
            Credentials credentials = Credentials.Anonymous;
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Please specify password or token.");
                return;
            }
            credentials = new Credentials(username.Text, password.Text);
            client.Credentials = credentials;
            try
            {
                list = await client.Repository.GetAllForCurrent().ConfigureAwait(true);
            }
            catch (AuthorizationException ex)
            {
                MessageBox.Show("Authorization failed.");
                return;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Failed to query GitHub instance at {baseUrl}.");
                return;
            }
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

        private void Check(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
            {
                ((RadioButton)sender).Checked = true;
            }
        }
    }
}
