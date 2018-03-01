using System.Collections.Generic;
using Sales.Models;

namespace Sales.Persistence
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesDbContext context)
            : base(context)
        {
        }
        public IEnumerable<Customer> GetCustomersByName(string Name)
        {
            return Find(c => c.Name.StartsWith(Name));
        }
    }
}