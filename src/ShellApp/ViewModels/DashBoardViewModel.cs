using Prism.Mvvm;
using Core.Contracts;
using Core.Services;
using System;
using Prism.Commands;
using ShellApp.Constants;
using System.Windows.Input;
using Prism.Events;

namespace ShellApp.ViewModels
{
    public class DashBoardViewModel : BindableBase
    {
        public DelegateCommand OpenCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        IEventAggregator _eventAggregator;
        public DashBoardViewModel(IEventAggregator ea, ITimerService timerService)
        {
            OpenCommand = new DelegateCommand(UpdateOpen);
            SaveCommand = new DelegateCommand(UpdateSave);
            CompositeCommands.OpenCommand.RegisterCommand(OpenCommand);
            CompositeCommands.SaveCommand.RegisterCommand(SaveCommand);
            _eventAggregator = ea;
        }

        private void UpdateOpen()
        {
            _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("Success Open Document");
        }

        private void UpdateSave()
        {
            _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("Success Save Document");
        }

        private string _title = $"DashBoard";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}