using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace SmtpClientTool
{
    public partial class MainForm : Form
    {
        SmtpClient client;

        public MainForm()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            send.Enabled = false;
            MailMessage mailMessage;
            try
            {
                mailMessage = new MailMessage(from.Text, to.Text);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                send.Enabled = true;
                return;
            }
            mailMessage.Body = message.Text;
            mailMessage.BodyEncoding = Encoding.ASCII;
            mailMessage.BodyTransferEncoding = TransferEncoding.QuotedPrintable;
            client = new SmtpClient(server.Text, Decimal.ToInt32(port.Value));
            client.SendCompleted += SendCompletedCallback;
            try
            {
                client.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
                client.Dispose();
                client = null;
                send.Enabled = true;
            }
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)delegate
                {
                    SendCompletedCallback(sender, e);
                });
                return;
            }
            client.Dispose();
            client = null;
            send.Enabled = true;
        }
    }
}
