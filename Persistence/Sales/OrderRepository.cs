using System;
using System.Collections.Generic;
using Sales.Models;

namespace Sales.Persistence
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(SalesDbContext context)
            : base(context)
        {
        }
        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            return Find(c => c.OrderDate == date);
        }
    }
}