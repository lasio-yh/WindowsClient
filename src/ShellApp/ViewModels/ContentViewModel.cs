using Core.Contracts;
using Core.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using ShellApp.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShellApp.ViewModels
{
    public class ContentViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;

        public ContentViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
            _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("STOCK0");
        }
        private string firstName = "John";
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName")
                {
                    return string.IsNullOrEmpty(this.firstName) ? "Required value" : null;
                }
                if (columnName == "LastName")
                {
                    return string.IsNullOrEmpty(this.lastName) ? "Required value" : null;
                }
                return null;
            }
        }
    }
}