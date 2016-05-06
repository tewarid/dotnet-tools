using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketSharpServerTool
{
    public class ServiceBehavior : WebSocketBehavior
    {
        public static event Action<ServiceBehavior> Open;
        public event Action<MessageEventArgs> Message;
        public event Action<CloseEventArgs> Close;

        protected override void OnOpen()
        {
            Open.Invoke(this);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Message.Invoke(e);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Close.Invoke(e);
        }

        public new void Send(byte[] data)
        {
            base.Send(data);
        }

        public new void Send(string data)
        {
            base.Send(data);
        }
    }
}
