using System.Collections.Generic;
using Sales.Models;

namespace Sales.Persistence
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SalesDbContext context)
            : base(context)
        {
        }
        public IEnumerable<Product> GetProductsByName(string Name)
        {
            return Find(c => c.Name.StartsWith(Name));
        }
    }
}