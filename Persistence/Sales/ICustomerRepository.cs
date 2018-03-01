using System.Collections.Generic;
using Sales.Models;

namespace Sales.Persistence
{
    public interface ICustomerRepository : IRepository<Customer> 
    {
        IEnumerable<Customer> GetCustomersByName(string Name);
    }
}