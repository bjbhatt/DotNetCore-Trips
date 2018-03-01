using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sales.Controllers.Resources
{
    //[Table("Products", Schema = "dbo")]
    public class ProductResource
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice {get; set;}

        public ICollection<OrderDetailResource> OrderDetails { get; set;}

        public ProductResource() 
        {
            OrderDetails = new Collection<OrderDetailResource>();
        }
    }
}