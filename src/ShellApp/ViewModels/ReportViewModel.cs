using System.Collections.ObjectModel;
using Prism.Mvvm;
using Core.Model;
using Core.Contracts;
using ShellApp.Constants;
using Prism.Commands;
using System.Windows;
using System.Windows.Input;
using ShellApp.Views;
using Prism.Events;

namespace ShellApp.ViewModels
{
    public class ReportViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        IEventAggregator _eventAggregator;

        public ReportViewModel(ICustomerService service, IEventAggregator ea)
        {
            Customers = new ObservableCollection<Customer>();
            Customers.AddRange(service.GetAllCustomers());

            ButtonCommand0 = CompositeCommands.SaveCommand;

            _eventAggregator = ea;
            _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("STOCK0");
        }

        private ICommand _buttonCommand0;
        public ICommand ButtonCommand0
        {
            get => _buttonCommand0;
            set => _buttonCommand0 = value;

        }

        private ICommand _buttonCommand1;
        public ICommand ButtonCommand1 => _buttonCommand1 ?? (_buttonCommand1 = new DelegateCommand<Customer>(OnButtonCommand1));
        private void OnButtonCommand1(Customer param)
        {
            Customers.Clear();
            EditDialog.ShowDialog("Command1","Command1 Show Message",MessageBoxButton.OK);
        }

        private ICommand _buttonCommand2;
        public ICommand ButtonCommand2 => _buttonCommand2 ?? (_buttonCommand2 = new DelegateCommand<Customer>(OnButton2Command));
        private void OnButton2Command(Customer param)
        {
            EditDialog.ShowWindow("", new Content(), 600, 768, MessageBoxButton.OK);
            EditDialog.ShowWindow("Command2", "Command2 Show Message",1020,768, MessageBoxButton.OK);
        }

        private ICommand _buttonCommand3;
        public ICommand ButtonCommand3 => _buttonCommand3 ?? (_buttonCommand3 = new DelegateCommand<Customer>(OnButtonCommand3));
        private void OnButtonCommand3(Customer param)
        {
            EditDialog.ShowDialog("Command3", "Command3 Show Message", MessageBoxButton.OK);
        }

        private ICommand _buttonCommand4;
        public ICommand ButtonCommand4 => _buttonCommand4 ?? (_buttonCommand4 = new DelegateCommand<Customer>(OnButtonCommand4));
        private void OnButtonCommand4(Customer param)
        {
            EditDialog.ShowDialog("Command4", "Command4 Show Message", MessageBoxButton.OK);
        }
    }
}