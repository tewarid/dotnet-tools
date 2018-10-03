using SmtpServer;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace SmtpServerTool
{
    public partial class MainForm : Form, IDisposable
    {
        private CancellationTokenSource cancellationTokenSource;
        private SmtpServer.SmtpServer smtpServer;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void Start_Click(object sender, EventArgs e)
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
                cancellationTokenSource = new CancellationTokenSource();
                await smtpServer.StartAsync(cancellationTokenSource.Token)
                    .ConfigureAwait(true);
            }
            catch(SocketException ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
            catch(OperationCanceledException)
            {
                // nothing for user to do
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
            // nothing to show or tell the user
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            cancellationTokenSource = null;
        }

        new void Dispose()
        {
            base.Dispose();
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Dispose();
            }
        }


        private void Clear_Click(object sender, EventArgs e)
        {
            log.Clear();
        }
    }
}
