using System;
using System.Reflection;
using System.Windows.Forms;

namespace Common
{
    public partial class InputDialog : Form
    {
        private InputDialog()
        {
            InitializeComponent();
        }

        public static DialogResult Show<T>(IWin32Window owner, string label,
            string defaultValue, out T value)
        {
            T inputValue = default(T);
            InputDialog dialog = new InputDialog();
            dialog.Text = label;
            dialog.label.Text = label;
            dialog.value.Text = defaultValue;
            DialogResult result = DialogResult.None;
            dialog.ok.Click += (o, a) =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(dialog.value.Text))
                    {
                        inputValue = (T)Activator.CreateInstance(typeof(T),
                            new object[] { dialog.value.Text });
                    }
                }
                catch(TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(dialog, ex.InnerException.Message,
                            dialog.Text);
                    }
                    return;
                }
                result = DialogResult.OK;
                dialog.Close();
            };
            dialog.cancel.Click += (o, a) =>
            {
                result = DialogResult.Cancel;
            };
            dialog.ShowDialog(owner);
            value = inputValue;
            return result;
        }
    }
}
