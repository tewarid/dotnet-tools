using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebSocketServerTool
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        Task Send(Message message);
    }
}
