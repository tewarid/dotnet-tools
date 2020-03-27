using System;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AmqpClient_Click(object sender, EventArgs e)
        {
            (new AmqpClientTool.MainForm()).Show();
        }

        private void azureEventHubClient_Click(object sender, EventArgs e)
        {
            (new AzureEventHubClientTool.MainForm()).Show();
        }

        private void BluetoothSerialClient_Click(object sender, EventArgs e)
        {
            (new BluetoothSerialClientTool.MainForm()).Show();
        }

        private void BluetoothSerialServer_Click(object sender, EventArgs e)
        {
            (new BluetoothSerialServerTool.MainForm()).Show();
        }

        private void EncodingTool_Click(object sender, EventArgs e)
        {
            (new EncodingTool.MainForm()).Show();
        }

        private void FirewallTool_Click(object sender, EventArgs e)
        {
            (new FirewallTool.MainForm()).Show();
        }

        private void FontTool_Click(object sender, EventArgs e)
        {
            (new FontTool.MainForm()).Show();
        }

        private void GitLabTool_Click(object sender, EventArgs e)
        {
            (new GitLabTool.MainForm()).Show();
        }

        private void GitTool_Click(object sender, EventArgs e)
        {
            (new GitTool.MainForm()).Show();
        }

        private void GlobalizationTool_Click(object sender, EventArgs e)
        {
            (new GlobalizationTool.MainForm()).Show();
        }

        private void UsbHidTool_Click(object sender, EventArgs e)
        {
            (new HidTool.MainForm()).Show();
        }

        private void HttpListener_Click(object sender, EventArgs e)
        {
            (new HttpListenerTool.MainForm()).Show();
        }

        private void HttpRequestTool_Click(object sender, EventArgs e)
        {
            (new HttpRequestTool.MainForm()).Show();
        }

        private void icmpTool_Click(object sender, EventArgs e)
        {
            (new IcmpTool.MainForm()).Show();
        }

        private void KafkaClient_Click(object sender, EventArgs e)
        {
            (new KafkaClientTool.MainForm()).Show();
        }

        private void MqttClient_Click(object sender, EventArgs e)
        {
            (new MqttClientTool.MainForm()).Show();
        }

        private void NetworkRouteTool_Click(object sender, EventArgs e)
        {
            (new RouteTool.MainForm()).Show();
        }

        private void NotificationTool_Click(object sender, EventArgs e)
        {
            (new NotificationTool.MainForm()).Show();
        }

        private void SerialPortTool_Click(object sender, EventArgs e)
        {
            (new SerialTool.MainForm()).Show();
        }

        private void SmtpClient_Click(object sender, EventArgs e)
        {
            (new SmtpClientTool.MainForm()).Show();
        }

        private void SmtpServer_Click(object sender, EventArgs e)
        {
            (new SmtpServerTool.MainForm()).Show();
        }

        private void NetworkSniffer_Click(object sender, EventArgs e)
        {
            (new SnifferTool.MainForm()).Show();
        }

        private void TcpClient_Click(object sender, EventArgs e)
        {
            (new TcpClientTool.MainForm()).Show();
        }

        private void TcpListener_Click(object sender, EventArgs e)
        {
            (new TcpListenerTool.MainForm()).Show();
        }

        private void udpTool_Click(object sender, EventArgs e)
        {
            (new UdpTool.MainForm()).Show();
        }

        private void WebSocketServer_Click(object sender, EventArgs e)
        {
            (new WebSocketServerTool.MainForm()).Show();
        }

        private void WebSocketClient_Click(object sender, EventArgs e)
        {
            (new WebSocketTool.MainForm()).Show();
        }

        private void WmiQueryTool_Click(object sender, EventArgs e)
        {
            (new WmiQuery.MainForm()).Show();
        }
    }
}
