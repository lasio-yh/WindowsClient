using Prism.Events;
using Prism.Mvvm;
using ShellApp.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellApp.ViewModels
{
    public class StatusViewModel : BindableBase
    {
        public StatusViewModel(IEventAggregator ea)
        {
            ea.GetEvent<TickerSymbolSelectedEvent>().Subscribe(Push);
        }

        private void Push(string args)
        {
            Message = args;
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
