using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    interface IService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        Task SendMessage(Message message);
    }
}
