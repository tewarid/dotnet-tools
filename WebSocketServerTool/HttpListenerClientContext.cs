using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    class HttpListenerClientContext : IClientContext
    {
        private HttpListenerContext listenerContext;
        private HttpListenerWebSocketContext wsContext;

        public event ClosedHandler Closed;
        public event MessageHandler Message;

        public HttpListenerClientContext(HttpListenerContext listenerContext)
        {
            this.listenerContext = listenerContext;
            Start();
        }

        private async void Start()
        {
            byte[] buffer = new byte[100];
            wsContext = await listenerContext.AcceptWebSocketAsync(null, TimeSpan.FromSeconds(30));
            while (true)
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                WebSocketReceiveResult result;
                try
                {
                    result = await wsContext.WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), token);
                }
                catch(WebSocketException)
                {
                    Closed?.Invoke();
                    break;
                }
                if (result.Count > 0)
                {
                    await Receive(buffer, result.Count, result.MessageType, result.EndOfMessage);
                }

                if (wsContext.WebSocket.State != WebSocketState.Open)
                {
                    Closed?.Invoke();
                    break;
                }
            }
        }

        public void Close()
        {
            CancellationToken cancellationToken = default(System.Threading.CancellationToken);
            wsContext.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, 
                "Closed by user.", cancellationToken);
        }

        public void Send(byte[] message, WebSocketMessageType type)
        {
            CancellationToken cancellationToken = default(System.Threading.CancellationToken);
            wsContext.WebSocket.SendAsync(new ArraySegment<byte>(message), 
                type, true, cancellationToken);
        }

        public async Task Receive(byte[] message, int length, WebSocketMessageType type, bool lastMessage)
        {
            await Task.Run(delegate ()
            {
                Message?.Invoke(message, length, type, lastMessage);
            });
        }
    }
}
