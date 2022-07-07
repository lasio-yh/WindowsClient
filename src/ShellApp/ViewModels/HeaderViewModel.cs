using Core.Contracts;
using Core.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellApp.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
        public HeaderViewModel(ITimerService timerService)
        {
            timerService = new TimerService();
            timerService.Create(GetCurentDate);
            timerService.Start();
        }

        private void GetCurentDate(object sender)
        {
            NowDay = string.Format("{0} ({1}) {2}", DateTime.Now.ToString("yyyy.MM.dd"), DateTime.Now.DayOfWeek, DateTime.Now.ToString("hh:mm:ss"));
        }

        private string _nowDay;
        public string NowDay
        {
            get { return _nowDay; }
            set { SetProperty(ref _nowDay, value); }
        }
    }
}
