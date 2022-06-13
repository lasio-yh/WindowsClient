using Prism.Mvvm;
using Core.Contracts;
using Core.Services;
using System;
using Prism.Commands;
using ShellApp.Constants;
using System.Windows.Input;

namespace ShellApp.ViewModels
{
    public class DashBoardViewModel : BindableBase
    {
        public DelegateCommand UpdateCommand { get; private set; }

        public DashBoardViewModel(ITimerService timerService)
        {
            timerService = new TimerService();
            timerService.Create(GetCurentDate);
            timerService.Start();
            UpdateCommand = new DelegateCommand(Update);
            CompositeCommands.SaveCommand.RegisterCommand(UpdateCommand);
        }

        private void Update()
        {

        }

        private void GetCurentDate(object sender)
        {
            NowDay = string.Format("{0} ({1})", DateTime.Now.ToString("yyyy.MM.dd"), DateTime.Now.DayOfWeek);
            NowTime = string.Format(" {0}", DateTime.Now.ToString("hh:mm:ss"));
        }

        private string _title = $"DashBoard";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _nowDay;
        public string NowDay
        {
            get { return _nowDay; }
            set { SetProperty(ref _nowDay, value); }
        }

        private string _nowTime;
        public string NowTime
        {
            get { return _nowTime; }
            set { SetProperty(ref _nowTime, value); }
        }
    }
}