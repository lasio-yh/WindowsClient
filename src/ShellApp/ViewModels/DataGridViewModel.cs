using System.Collections.ObjectModel;
using Prism.Mvvm;
using Core.Model;
using Core.Contracts;
using ShellApp.Constants;
using Prism.Commands;
using System.Windows;
using System.Windows.Input;

namespace ShellApp.ViewModels
{
    public class DataGridViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        public DataGridViewModel(ICustomerService service, ITCPService server)
        {
            Customers = new ObservableCollection<Customer>();
            Customers.AddRange(service.GetAllCustomers());
        }

        private ICommand _button1Command;
        public ICommand Button1Command => _button1Command ?? (_button1Command = new DelegateCommand<Customer>(OnButton1Command));
        private void OnButton1Command(Customer param)
        {
            EditDialog.ShowMessage("Command1","Command1 Show Message",MessageBoxButton.OK);
        }

        private ICommand _button2Command;
        public ICommand Button2Command => _button2Command ?? (_button2Command = new DelegateCommand<Customer>(OnButton2Command));
        private void OnButton2Command(Customer param)
        {
            EditDialog.ShowMessage("Command2", "Command2 Show Message", MessageBoxButton.OK);
        }

        private ICommand _button3Command;
        public ICommand Button3Command => _button3Command ?? (_button3Command = new DelegateCommand<Customer>(OnButton3Command));
        private void OnButton3Command(Customer param)
        {
            EditDialog.ShowMessage("Command3", "Command3 Show Message", MessageBoxButton.OK);
        }

        private ICommand _button4Command;
        public ICommand Button4Command => _button4Command ?? (_button4Command = new DelegateCommand<Customer>(OnButton4Command));
        private void OnButton4Command(Customer param)
        {
            EditDialog.ShowMessage("Command4", "Command4 Show Message", MessageBoxButton.OK);
        }
    }
}