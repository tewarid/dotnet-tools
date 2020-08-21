using DesktopBridge;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {
        IList<Assembly> _assemblies;

        public MainForm()
        {
            InitializeComponent();
            _assemblies = GetAllAssemblies();
            Add(_assemblies);
        }

        private void Add(IList<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var attribute = (AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).FirstOrDefault();
                var name = attribute?.Title ?? assembly.GetName().Name;
                Button button = CreateButton(name);
                button.Click += (sender, e) =>
                {
                    Process.Start(assembly.Location);
                };

                panel.Controls.Add(button);
                panel.Controls.SetChildIndex(button, panel.Controls.Count - 1);
            }
        }

        private Button CreateButton(string name)
        {
            Button button = new Button();
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Popup;
            button.Location = new System.Drawing.Point(3, 3);
            button.Size = new System.Drawing.Size(250, 30);
            button.Text = name;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.UseVisualStyleBackColor = true;
            return button;
        }

        private IList<Assembly> GetAllAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string path = Path.GetDirectoryName(executingAssembly.Location);
            Helpers helpers = new Helpers();
            if (helpers.IsRunningAsUwp())
            {
                path = Directory.GetParent(path).FullName;
            }
#if NETCOREAPP
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
#else
            var files = Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories);
#endif
            foreach (string file in files)
            {
                var assembly = Assembly.LoadFile(file);
                if (executingAssembly.Equals(assembly))
                {
                    continue;
                }
                assemblies.Add(assembly);
            }
            return assemblies;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
