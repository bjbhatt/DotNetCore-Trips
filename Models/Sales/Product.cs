using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sales.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice {get; set;}

        #region Navigation Properties

        public ICollection<OrderDetail> OrderDetails { get; set;}

        #endregion

        #region Constructors

        public Product() 
        {
            OrderDetails = new Collection<OrderDetail>();
        }

        #endregion
    }
}