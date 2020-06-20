using Common;
using GitLabApiClient;
using GitLabApiClient.Models.Groups.Requests;
using GitLabApiClient.Models.Groups.Responses;
using GitLabApiClient.Models.Milestones.Responses;
using GitLabApiClient.Models.Projects.Requests;
using GitLabApiClient.Models.Projects.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitLabTool
{
    [MainForm(Name = "GitLab Tool")]
    public partial class MainForm : Form
    {
        private GitLabClient client;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void query_Click(object sender, EventArgs e)
        {
            query.Enabled = false;
            try
            {
                await Query(filter.Text).ConfigureAwait(true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            query.Enabled = true;
        }

        private async Task Query(string filter)
        {
            CreateClient();
            IList<Project> projectList;
            projectList = await client.Projects.GetAsync((o) =>
            {
                o.Filter = filter;
                o.Owned = true;
            }).ConfigureAwait(true);
            projects.Items.Clear();
            milestones.Items.Clear();
            foreach (var project in projectList)
            {
                ListViewItem projectListItem = new ListViewItem(new string[] {
                    project.PathWithNamespace,
                    project.HttpUrlToRepo,
                    project.SshUrlToRepo });
                projectListItem.Tag = project;
                projects.Items.Add(projectListItem);
                try
                {
                    var milestoneList = await client.Projects
                        .GetMilestonesAsync(project.Id, (options) =>
                        {
                            options.State = MilestoneState.All;
                        }).ConfigureAwait(true);
                    foreach (var milestone in milestoneList)
                    {
                        ListViewItem milestoneListItem = new ListViewItem(new string[] {
                            milestone.DueDate,
                            project.PathWithNamespace,
                            milestone.Title,
                            milestone.State.ToString(),
                            milestone.StartDate});
                        milestoneListItem.Tag = milestone;
                        milestones.Items.Add(milestoneListItem);
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

        private async void CreateClient()
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                client = new GitLabClient(host.Text, password.Text);
            }
            else
            {
                client = new GitLabClient(host.Text);
                _ = await client.LoginAsync(username.Text, password.Text);
            }
        }

        private void Projects_KeyDown(object sender, KeyEventArgs e)
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

        private async void Create_Click(object sender, EventArgs e)
        {
            InputDialog<string> dialog = new InputDialog<string>();
            DialogResult result = dialog.Show(this,
                "Input project namespace and name", string.Empty);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            CreateClient();
            string path;
            Group group = null;
            int index = dialog.Value.LastIndexOf("/");
            if (index == -1)
            {
                path = dialog.Value;
            }
            else
            {
                path = dialog.Value.Substring(index + 1);
                string groupPathWithNamespace = dialog.Value.Substring(0, index);
                group = await GetOrCreateGroup(groupPathWithNamespace)
                    .ConfigureAwait(true);
                if (group == null)
                {
                    MessageBox.Show(this, $"Could not create group {groupPathWithNamespace}");
                    return;
                }
            }
            CreateProjectRequest request = CreateProjectRequest.FromPath(path);
            request.NamespaceId = group.Id;
            try
            {
                await client.Projects.CreateAsync(request).ConfigureAwait(true);
            }
            catch(GitLabException ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            dialog.Dispose();
        }

        private async Task<Group> GetOrCreateGroup(string pathWithNamespace)
        {
            string[] path = pathWithNamespace.Split('/');
            Group group;
            try
            {
                group = await client.Groups.GetAsync(path[0])
                    .ConfigureAwait(true);
            }
            catch (GitLabException)
            {
                try
                {
                    CreateGroupRequest request = new CreateGroupRequest(path[0], path[0]);
                    group = await client.Groups.CreateAsync(request);
                }
                catch (GitLabException)
                {
                    return null;
                }
            }
            for (int i = 1; i < path.Length; i++)
            {
                Group subgroup = await GetSubgroup(group.Id, path[i]).ConfigureAwait(true);
                if (subgroup != null)
                {
                    group = subgroup;
                    continue;
                }
                try
                {
                    CreateGroupRequest request = new CreateGroupRequest(path[i], path[i]);
                    request.ParentId = group.Id;
                    request.Visibility = group.Visibility;
                    group = await client.Groups.CreateAsync(request).ConfigureAwait(false);
                }
                catch (GitLabException)
                {
                    group = null;
                    break;
                }
            }
            return group;
        }

        private async Task<Group> GetSubgroup(int parentId, string path)
        {
            try
            {
                IList<Group> subGroups = await client.Groups.GetSubgroupsAsync(parentId.ToString());
                foreach (Group subGroup in subGroups)
                {
                    if (subGroup.Path.Equals(path))
                    {
                        return subGroup;
                    }
                }
            }
            catch (GitLabException)
            {
                // do nothing
            }
            return null;
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            if (projects.SelectedIndices.Count == 0)
            {
                return;
            }
            Project project = (Project)projects.Items[projects.SelectedIndices[0]].Tag;
            DialogResult result = MessageBox.Show(this,
                $"Are you sure you want to delete project {project.PathWithNamespace}?",
                Text, MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await client.Projects.DeleteAsync(project.Id).ConfigureAwait(true);
                }
                catch (GitLabException ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }
    }
}
