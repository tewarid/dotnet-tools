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
        private readonly Task task;

        public event ClosedHandler Closed;
        public event MessageHandler Message;

        public HttpListenerClientContext(HttpListenerContext listenerContext)
        {
            this.listenerContext = listenerContext;
            task = Start();
        }

        private async Task Start()
        {
            byte[] buffer = new byte[100];
            wsContext = await listenerContext.AcceptWebSocketAsync(null, TimeSpan.FromSeconds(30));
            while (true)
            {
                WebSocketReceiveResult result;
                try
                {
                    CancellationTokenSource cts = new CancellationTokenSource();
                    CancellationToken token = cts.Token;
                    result = await wsContext.WebSocket
                        .ReceiveAsync(new ArraySegment<byte>(buffer), token);
                    cts.Dispose();
                }
                catch(WebSocketException)
                {
                    Closed?.Invoke();
                    break;
                }
                if (result.Count > 0)
                {
                    await Receive(buffer, result.Count, result.MessageType,
                        result.EndOfMessage).ConfigureAwait(true);
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
            CancellationToken cancellationToken = default(CancellationToken);
            wsContext.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, 
                "Closed by user.", cancellationToken);
        }

        public void Send(byte[] message, WebSocketMessageType type)
        {
            CancellationToken cancellationToken = default(CancellationToken);
            wsContext.WebSocket.SendAsync(new ArraySegment<byte>(message), 
                type, true, cancellationToken);
        }

        public async Task Receive(byte[] message, int length, WebSocketMessageType type, bool lastMessage)
        {
            await Task.Run(delegate
            {
                Message?.Invoke(message, length, type, lastMessage);
            }).ConfigureAwait(true);
        }
    }
}
