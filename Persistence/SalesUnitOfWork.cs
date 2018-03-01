using System.Threading.Tasks;

namespace Sales.Persistence
{
    public class SalesUnitOfWork : ISalesUnitOfWork
    {
        private readonly SalesDbContext _context;
        public ICustomerRepository Customers { get; private set; }
        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderDetailRepository OrderDetails { get; private set; }
        
        public SalesUnitOfWork(SalesDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
            OrderDetails = new OrderDetailRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}