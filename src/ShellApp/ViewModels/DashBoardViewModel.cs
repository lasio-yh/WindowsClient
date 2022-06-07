using System.Collections.ObjectModel;
using Prism.Mvvm;
using Core.Model;
using Core.Contracts;
using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;

namespace ShellApp.ViewModels
{
    public class DashBoardViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        public DashBoardViewModel(ICustomerService service)
        {
            Customers = new ObservableCollection<Customer>();
            Customers.AddRange(service.GetAllCustomers());
        }
    }
}