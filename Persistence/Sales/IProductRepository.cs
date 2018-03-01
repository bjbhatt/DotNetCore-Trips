using System.Collections.Generic;
using Sales.Models;

namespace Sales.Persistence
{
    public interface IProductRepository : IRepository<Product> 
    {
        IEnumerable<Product> GetProductsByName(string Name);
    }
}