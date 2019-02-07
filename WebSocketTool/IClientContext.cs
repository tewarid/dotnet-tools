using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    public interface IClientContext
    {
        event ClosedHandler Closed;
        event MessageHandler Message;

        void Close();
        Task Receive(byte[] message, int length, WebSocketMessageType type, bool lastMessage);
        void Send(byte[] message, WebSocketMessageType type);
    }
}