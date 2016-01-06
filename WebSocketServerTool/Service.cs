using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class Service : IService
    {
        const string webSocketMessageProperty = "WebSocketMessageProperty";

        private Message CreateMessage(byte[] message,
            WebSocketMessageType type = WebSocketMessageType.Binary)
        {
            Message channelMessage = ByteStreamMessage.CreateMessage(new ArraySegment<byte>(message));

            channelMessage.Properties[webSocketMessageProperty] =
                new WebSocketMessageProperty { MessageType = type };

            return channelMessage;
        }

        public async Task SendMessage(Message message)
        {
            if (message.IsEmpty) return;

            byte[] body = message.GetBody<byte[]>();
            WebSocketMessageProperty property = 
                (WebSocketMessageProperty)message.Properties[webSocketMessageProperty];
            WebSocketMessageType type = property.MessageType;

            IServiceCallback callback = 
                OperationContext.Current.GetCallbackChannel<IServiceCallback>();

            IChannel channel = (IChannel)callback;
            channel.Faulted += channel_Faulted;
            channel.Closed += channel_Closed;

            if (channel.State == CommunicationState.Opened)
                await callback.ReceiveMessage(CreateMessage(body, type));
        }

        private void channel_Closed(object sender, EventArgs e)
        {
            // Clean up
        }

        private void channel_Faulted(object sender, EventArgs e)
        {
            // Clean up
        }
    }
}
