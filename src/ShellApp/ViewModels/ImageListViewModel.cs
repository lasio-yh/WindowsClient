using Core.Contracts;
using Core.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellApp.ViewModels
{
    public class ImageListViewModel : BindableBase
    {
        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }

        private Customer _selected;
        public Customer Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private bool _isMember;
        public bool IsMember
        {
            get { return _isMember; }
            set { SetProperty(ref _isMember, value); }
        }

        private OrderStatus _status;
        public OrderStatus Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public ImageListViewModel(ICustomerService service)
        {
            Customers = new ObservableCollection<Customer>();
            Customers.AddRange(service.GetAllCustomers());
        }
    }
}