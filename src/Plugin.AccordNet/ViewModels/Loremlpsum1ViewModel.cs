using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using Core.Model;
using Core.Contracts;

namespace Plugin.AccordNet.ViewModels
{
    public class Loremlpsum1ViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers1
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        public Loremlpsum1ViewModel(ICustomerService service)
        {
            Customers1 = new ObservableCollection<Customer>();
            Customers1.AddRange(service.GetAllCustomers().OrderBy(c => c.LastName));
        }
    }
}
