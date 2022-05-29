using Core.Model;
using static Core.Services.TCPService;

namespace Core.Contracts
{
    public interface ITCPService
    {
        ResultMapModel Create(string ipAddress, int port);
        ResultMapModel StartReceive(CallBackHandler callBack);
        ResultMapModel StopReceive();
        ResultMapModel Send(byte[] buffer, int length);
    }
}
