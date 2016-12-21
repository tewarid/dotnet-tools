using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    [ServiceContract]
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        Task Callback(Message message);
    }
}
