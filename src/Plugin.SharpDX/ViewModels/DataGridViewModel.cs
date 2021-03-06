using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using Core.Model;
using Core.Services;
using Core.Contracts;

namespace Plugin.SharpDX.ViewModels
{
    public class DataGridViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        public DataGridViewModel(ICustomerService service)
        {
            Customers = new ObservableCollection<Customer>();
            Customers.AddRange(service.GetAllCustomers().OrderBy(c => c.FirstName));
        }
    }
}
