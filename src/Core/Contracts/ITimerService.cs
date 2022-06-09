using static Core.Services.TimerService;

namespace Core.Contracts
{
    public interface ITimerService
    {
        void Create(PushHandler callBack);
        void Start();
        void Stop();
    }
}
