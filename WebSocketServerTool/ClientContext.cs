using System;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    public delegate void ClosedHandler();
    public delegate void MessageHandler(byte[] message, WebSocketMessageType type);

    public class ClientContext
    {
        public event MessageHandler Message;
        public event ClosedHandler Closed;

        const string webSocketMessageProperty = "WebSocketMessageProperty";
        private IServiceCallback callback;

        public ClientContext(IServiceCallback callback)
        {
            this.callback = callback;

            IChannel channel = (IChannel)callback;
            channel.Faulted += delegate (object sender, EventArgs e)
            {
            };
            channel.Closed += delegate (object sender, EventArgs e)
            {
                Closed?.Invoke();
                Message = null;
                Closed = null;
            };
        }

        public void Send(byte[] message, WebSocketMessageType type)
        {
            IChannel channel = (IChannel)callback;
            if (channel.State == CommunicationState.Opened)
                callback.Callback(CreateMessage(message, type));
        }

        private Message CreateMessage(byte[] message,
            WebSocketMessageType type = WebSocketMessageType.Binary)
        {
            Message channelMessage = ByteStreamMessage.CreateMessage(new ArraySegment<byte>(message));

            channelMessage.Properties[webSocketMessageProperty] =
                new WebSocketMessageProperty { MessageType = type };

            return channelMessage;
        }

        public async Task Receive(Message message)
        {
            if (message.IsEmpty)
            {
                // New connection notification probably because
                // CreateNotificationOnConnection = true

                return;
            }

            byte[] body = message.GetBody<byte[]>();

            WebSocketMessageProperty property =
                (WebSocketMessageProperty)message.Properties[webSocketMessageProperty];

            await Task.Run(delegate ()
            {
                Message?.Invoke(body, property.MessageType);
            });
        }

        public void Close()
        {
            IChannel channel = (IChannel)callback;
            channel.BeginClose(delegate(IAsyncResult ar)
            {
                try
                {
                    channel.EndClose(ar);
                }
                catch (TimeoutException ex)
                { }
            }, null);
        }
    }
}
