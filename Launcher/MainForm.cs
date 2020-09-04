using DesktopBridge;
using System;
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
        IList<Tuple<string, Assembly>> _assemblies;

        public MainForm()
        {
            InitializeComponent();
            _assemblies = GetAllAssemblies();
            Add(_assemblies);
        }

        private void Add(IList<Tuple<string, Assembly>> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                Button button = CreateButton(assembly.Item1);
                button.Click += (sender, e) =>
                {
                    string path = assembly.Item2.Location;
#if NETCOREAPP
                    path = Path.ChangeExtension(path, "exe");
#endif
                    Process.Start(path);
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

        private IList<Tuple<string, Assembly>> GetAllAssemblies()
        {
            Dictionary<string, Tuple<string, Assembly>> assemblies = new Dictionary<string, Tuple<string, Assembly>>();
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
                if (executingAssembly.Location.Equals(file))
                {
                    continue;
                }
#if NETCOREAPP
                if (!File.Exists(Path.ChangeExtension(file, "exe")))
                {
                    continue;
                }
#endif
                Assembly assembly = Assembly.LoadFile(file);
                var attribute = (AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).FirstOrDefault();
                var name = attribute?.Title ?? assembly.GetName().Name;
                if (!assemblies.ContainsKey(name))
                {
                    assemblies.Add(name, new Tuple<string, Assembly>(name, assembly));
                }
            }
            return assemblies.Values.ToList();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
