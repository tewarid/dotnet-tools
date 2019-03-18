using GitLabApiClient;
using GitLabApiClient.Models.Milestones.Responses;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitLabTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void query_Click(object sender, EventArgs e)
        {
            try
            {
                await Query().ConfigureAwait(true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private async Task Query()
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
            var projectList = await client.Projects.GetAsync().ConfigureAwait(true);
            projects.Items.Clear();
            milestones.Items.Clear();
            foreach (var project in projectList)
            {
                projects.Items.Add(new ListViewItem(new string[] {
                    project.PathWithNamespace,
                    project.Namespace.Name,
                    project.HttpUrlToRepo,
                    project.SshUrlToRepo }));
                try
                {
                    var milestoneList = await client.Projects
                        .GetMilestonesAsync(project.Id, (options) =>
                        {
                            options.State = MilestoneState.All;
                        }).ConfigureAwait(true);
                    foreach (var milestone in milestoneList)
                    {
                        milestones.Items.Add(new ListViewItem(new string[] {
                            milestone.DueDate,
                            project.PathWithNamespace,
                            milestone.Title,
                            milestone.State.ToString(),
                            milestone.StartDate}));
                    }
                }
                catch (GitLabException ex)
                {
                    if (ex.HttpStatusCode == HttpStatusCode.Forbidden)
                    {
                        continue;
                    }
                }
            }
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyListBox((ListView)sender);
            }
        }

        public void CopyListBox(ListView list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list.SelectedItems)
            {
                ListViewItem l = item as ListViewItem;
                if (l != null)
                {
                    foreach(ListViewItem.ListViewSubItem sub in l.SubItems)
                    {
                        sb.Append(sub.Text + "\t");
                    }
                }
                sb.AppendLine();
            }
            Clipboard.SetDataObject(sb.ToString());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
