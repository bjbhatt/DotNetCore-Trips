using System;
using System.Collections.Generic;
using Sales.Models;

namespace Sales.Persistence
{
    public interface IOrderRepository : IRepository<Order> 
    {
        IEnumerable<Order> GetOrdersByDate(DateTime date);
    }
}