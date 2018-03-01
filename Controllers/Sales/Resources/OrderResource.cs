using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sales.Controllers.Resources
{
    public class OrderResource

    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerResource Customer { get; set; }
        public ICollection<OrderDetailResource> OrderDetails { get; set;}

        public OrderResource() 
        {
            OrderDetails = new Collection<OrderDetailResource>();
        }
    }
}