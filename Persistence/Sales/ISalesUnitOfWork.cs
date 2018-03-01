using System;
using System.Threading.Tasks;

namespace Sales.Persistence
{
    public interface ISalesUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        int Complete();
    }
}