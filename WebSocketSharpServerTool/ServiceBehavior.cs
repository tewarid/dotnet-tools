using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketServerTool
{
    class ServiceBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.IsBinary)
                base.Send(e.RawData);
            else
                base.Send(e.Data);
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }
    }
}
