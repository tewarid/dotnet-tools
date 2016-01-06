using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    [ServiceContract]
    interface IServiceCallback
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        Task ReceiveMessage(Message message);
    }
}
