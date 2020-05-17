using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {
        List<Form> activeForms = new List<Form>();

        public MainForm()
        {
            InitializeComponent();
            Type[] forms = GetAllMainForm();
            Add(forms);
        }

        private void Add(Type[] forms)
        {
            foreach (var type in forms)
            {
                var name = type.Name;
                var attributes = (MainFormAttribute[])type.GetCustomAttributes(typeof(MainFormAttribute), false);
                if (attributes.Length > 0)
                {
                    name = attributes?[0].Name;
                }
                Button button = CreateButton(name);
                button.Click += (sender, e) =>
                {
                    Form form = (Form)Activator.CreateInstance(type);
                    activeForms.Add(form);
                    form.Disposed += (sender2, e2) =>
                    {
                        activeForms.Remove(form);
                        if (activeForms.Count != 0)
                        {
                            activeForms.LastOrDefault().BringToFront();
                        }
                        else if (Visible)
                        {
                            BringToFront();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    };
                    form.Show();
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

        private Type[] GetAllMainForm()
        {
            List<Type> forms = new List<Type>();
            Assembly[] assemblies = GetAllAssemblies();
            foreach (var assembly in assemblies)
            {
                IEnumerable<Type> types;
                try
                {
                    types = from type in assembly.GetTypes()
                                where Attribute.IsDefined(type, typeof(MainFormAttribute))
                                select type;
                }
                catch
                {
                    continue;
                }
                foreach (var type in types)
                {
                    forms.Add(type);
                }
            }
            var orderedForms = forms.OrderBy(t => ((MainFormAttribute)t.GetCustomAttributes(typeof(MainFormAttribute), false)[0]).Name);
            return orderedForms.ToArray();
        }

        private Assembly[] GetAllAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#if NETCOREAPP
            foreach (string assembly in Directory.GetFiles(path, "*.dll"))
#else
            foreach (string assembly in Directory.GetFiles(path, "*.exe"))
#endif
            {
                assemblies.Add(Assembly.LoadFile(assembly));
            }
            return assemblies.ToArray();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (activeForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
