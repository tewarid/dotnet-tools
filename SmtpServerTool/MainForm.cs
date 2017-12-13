using SmtpServer;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace SmtpServerTool
{
    public partial class MainForm : Form
    {
        readonly CancellationTokenSource cancellationTokenSource =
            new CancellationTokenSource();
        private SmtpServer.SmtpServer smtpServer;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void start_Click(object sender, EventArgs e)
        {
            EnableDisable(false);
            TimeSpan seconds =
                TimeSpan.FromSeconds(Decimal.ToDouble(timeout.Value));
            LoggingMessageStore store = new LoggingMessageStore();
            store.Message += Store_Message;
            ISmtpServerOptions options = new OptionsBuilder()
                .ServerName(serverName.Text)
                .Port(Decimal.ToInt32(port.Value))
                .CommandWaitTimeout(seconds)
                .MessageStore(store)
                .Build();
            smtpServer = new SmtpServer.SmtpServer(options);
            smtpServer.SessionCreated += OnSessionCreated;
            try
            {
                await smtpServer.StartAsync(cancellationTokenSource.Token);
            }
            catch(SocketException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
            catch(OperationCanceledException)
            {

            }
            EnableDisable(true);
        }

        private void EnableDisable(bool enabled)
        {
            serverName.ReadOnly = !enabled;
            port.ReadOnly = !enabled;
            timeout.ReadOnly = !enabled;
            start.Enabled = enabled;
            stop.Enabled = !enabled;
        }

        private void Store_Message(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Store_Message(message);
                });
                return;
            }
            log.AppendText(message);
            log.AppendText(Environment.NewLine);
            log.AppendText(Environment.NewLine);
        }

        private void OnSessionCreated(object sender, SessionEventArgs e)
        {
            e.Context.CommandExecuting += OnCommandExecuting;
        }

        private void OnCommandExecuting(object sender, SmtpCommandExecutingEventArgs e)
        {
        }

        private void stop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            log.Clear();
        }
    }
}
