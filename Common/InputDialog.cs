using System;
using System.Reflection;
using System.Windows.Forms;

namespace Common
{
    public partial class InputDialog<T> : Form
    {
        public T Value { get; private set; }

        public InputDialog()
        {
            InitializeComponent();
        }

        public DialogResult Show(IWin32Window owner, string label,
            string defaultValue)
        {
            this.Text = label;
            this.label.Text = label;
            this.value.Text = defaultValue;
            DialogResult result = DialogResult.None;
            this.ok.Click += (o, a) =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(this.value.Text))
                    {
                        Value = (T)Activator.CreateInstance(typeof(T),
                            new object[] { this.value.Text });
                    }
                }
                catch(TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(this, ex.InnerException.Message,
                            this.Text);
                    }
                    return;
                }
                result = DialogResult.OK;
                this.Close();
            };
            this.cancel.Click += (o, a) =>
            {
                result = DialogResult.Cancel;
            };
            this.ShowDialog(owner);
            return result;
        }
    }
}
