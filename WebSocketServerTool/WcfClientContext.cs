using System;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    public delegate void ClosedHandler();
    public delegate void MessageHandler(byte[] message, int length,
        WebSocketMessageType type, bool lastMessage);

    public class WcfClientContext : IClientContext
    {
        public event MessageHandler Message;
        public event ClosedHandler Closed;

        private IServiceCallback callback;

        public WcfClientContext(IServiceCallback callback)
        {
            this.callback = callback;

            IChannel channel = (IChannel)callback;
            channel.Faulted += delegate
            {
            };
            channel.Closed += delegate
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
            {
                callback.Callback(CreateMessage(message, type));
            }
        }

        private static Message CreateMessage(byte[] message,
            WebSocketMessageType type = WebSocketMessageType.Binary)
        {
            Message channelMessage = 
                ByteStreamMessage.CreateMessage(new ArraySegment<byte>(message));

            channelMessage.Properties[Service.webSocketMessageProperty] =
                new WebSocketMessageProperty { MessageType = type };

            return channelMessage;
        }

        public async Task Receive(byte[] message, int length,
            WebSocketMessageType type, bool lastMessage)
        {
            if (length == 0)
            {
                // New connection notification probably because
                // CreateNotificationOnConnection = true in service config
                return;
            }

            await Task.Run(delegate ()
            {
                Message?.Invoke(message, length, type, lastMessage);
            }).ConfigureAwait(true);
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
                catch (TimeoutException)
                {
                    // ignore timeout
                }
            }, null);
        }
    }
}
