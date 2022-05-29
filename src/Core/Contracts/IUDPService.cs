using Core.Model;
using static Core.Services.UDPService;

namespace Core.Contracts
{
    public interface IUDPService
    {
        ResultMapModel Create();
        ResultMapModel StartReceive(int port, CallBackHandler callBack);
        ResultMapModel StopReceive();
        ResultMapModel Send(byte[] buffer, int length);
    }
}
