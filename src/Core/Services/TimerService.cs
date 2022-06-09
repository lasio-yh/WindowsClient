using Core.Contracts;
using System;
using System.Windows.Threading;

namespace Core.Services
{
    public class TimerService : ITimerService
    {
        public DispatcherTimer _timer = new DispatcherTimer();
        public delegate void PushHandler(object args);
        public PushHandler Push;

        public void Create(PushHandler callBack)
        {
            Push = callBack;
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += OnTimer;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            Push(e);
        }
    }
}