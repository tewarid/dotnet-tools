using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketServerTool
{
    class ServiceBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            base.Send(e.RawData);
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }
    }
}
