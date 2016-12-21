using System.Collections.Concurrent;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class Service : IService
    {
        ConcurrentDictionary<IChannel, ClientContext> callbacks = 
            new ConcurrentDictionary<IChannel, ClientContext>();

        public async Task Send(Message message)
        {
            IServiceCallback callback = 
                OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            IChannel channel = (IChannel)callback;

            ClientContext context;

            if (!callbacks.TryGetValue(channel, out context))
            {
                context = new ClientContext(callback);
                callbacks[channel] = context;

                ClientForm clientForm = new ClientForm(context);
                clientForm.Show();
            }

            await context.Receive(message);
        }
    }
}
