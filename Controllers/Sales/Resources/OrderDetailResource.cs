using System;

namespace Sales.Controllers.Resources
{
    public class OrderDetailResource
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderResource Order { get; set; }
        public ProductResource Product { get; set; }
    }
}