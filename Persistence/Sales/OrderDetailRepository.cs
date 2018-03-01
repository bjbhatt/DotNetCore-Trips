using Sales.Models;

namespace Sales.Persistence
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SalesDbContext context)
            : base(context)
        {
        }
    }
}