using System.Collections.Generic;
using Core.Model;

namespace Core.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
    }
}
