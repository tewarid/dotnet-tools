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

        public DialogResult Show(IWin32Window owner, string labelText,
            string defaultValue)
        {
            Text = labelText;
            label.Text = labelText;
            value.Text = defaultValue;
            DialogResult result = DialogResult.None;
            ok.Click += (o, a) =>
            {
                try
                {
                    if (typeof(T) == typeof(String))
                    {
                        Value = (T)((object)value.Text);
                    }
                    else if (!string.IsNullOrWhiteSpace(value.Text))
                    {
                        Value = (T)Activator.CreateInstance(typeof(T),
                            new object[] { value.Text });
                    }
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(this, ex.InnerException.Message, Text);
                    }
                    return;
                }
                result = DialogResult.OK;
                Close();
            };
            cancel.Click += (o, a) =>
            {
                result = DialogResult.Cancel;
            };
            ShowDialog(owner);
            return result;
        }
    }
}
