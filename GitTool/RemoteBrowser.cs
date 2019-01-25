using Octokit;
using System;
using System.Windows.Forms;

namespace GitTool
{
    public partial class RemoteBrowser : Form
    {
        private readonly string GITHUB_HOST = "https://github.com";
        private readonly string GITLAB_HOST = "https://gitlab.com";

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

        private void gitHub_CheckedChanged(object sender, EventArgs e)
        {
            if (gitHub.Checked)
            {
                host.Text = GITHUB_HOST;
            }
        }

        private void gitLab_CheckedChanged(object sender, EventArgs e)
        {
            if (gitLab.Checked)
            {
                host.Text = GITLAB_HOST;
            }
        }

        private async void query_Click(object sender, EventArgs e)
        {
            query.Enabled = false;
            var ghe = host.Text;
            var phv = new ProductHeaderValue(username.Text);
            GitHubClient client;
            if (!ghe.Contains(GITHUB_HOST)) {
                client = new GitHubClient(phv);
            }
            else
            {
                client = new GitHubClient(phv, new Uri(host.Text));
            }
            var credentials = new Credentials(username.Text, password.Text);
            client.Credentials = credentials;
            var list = await client.Repository.GetAllForCurrent().ConfigureAwait(true);
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
            query.Enabled = true;
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
    }
}
