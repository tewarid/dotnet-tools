using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class Service : IService
    {
        public const string webSocketMessageProperty = "WebSocketMessageProperty";
        private readonly ConcurrentDictionary<IChannel, WcfClientContext> callbacks = 
            new ConcurrentDictionary<IChannel, WcfClientContext>();

        public async Task Send(Message message)
        {
            IServiceCallback callback = 
                OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            IChannel channel = (IChannel)callback;

            WcfClientContext context;

            if (!callbacks.TryGetValue(channel, out context))
            {
                context = new WcfClientContext(callback);
                callbacks[channel] = context;

                context.Closed += delegate()
                {
                    callbacks.TryRemove(channel, out context);
                };

                ClientForm clientForm = new ClientForm(context);
                clientForm.Show();
            }

            byte[] body = new byte[] { };
            if (!message.IsEmpty)
            {
                body = message.GetBody<byte[]>();
            }

            WebSocketMessageProperty property =
                (WebSocketMessageProperty)message.Properties[webSocketMessageProperty];

            await context.Receive(body, body.Length, property == null ? 
                WebSocketMessageType.Binary : property.MessageType, true)
                .ConfigureAwait(true);
        }
    }
}
