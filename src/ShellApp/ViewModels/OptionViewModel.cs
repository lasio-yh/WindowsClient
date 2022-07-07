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
    public class OptionViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;

        public OptionViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
        }

        private bool _isCheckedOption1;
        public bool IsCheckedOption1
        {
            get => _isCheckedOption1;
            set
            {
                _isCheckedOption1 = value;
                OnPropertyChanged("IsCheckedOption1");
                _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("IsCheckedOption1");
            }
        }

        private bool _isCheckedOption2;
        public bool IsCheckedOption2
        {
            get => _isCheckedOption2;
            set
            {
                _isCheckedOption2 = value;
                OnPropertyChanged("IsCheckedOption2");
                _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("IsCheckedOption2");
            }
        }

        private bool _isCheckedOption3;
        public bool IsCheckedOption3
        {
            get => _isCheckedOption3;
            set
            {
                _isCheckedOption3 = value;
                OnPropertyChanged("IsCheckedOption3");
                _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("IsCheckedOption3");
            }
        }

        private bool _isCheckedOption4;
        public bool IsCheckedOption4
        {
            get => _isCheckedOption4;
            set
            {
                _isCheckedOption4 = value;
                OnPropertyChanged("IsCheckedOption4");
                _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("IsCheckedOption4");
            }
        }
    }
}
