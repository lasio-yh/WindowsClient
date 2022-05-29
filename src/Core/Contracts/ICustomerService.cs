using System.Collections.Generic;
using Core.Model;

namespace Core.Contracts
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
    }
}
