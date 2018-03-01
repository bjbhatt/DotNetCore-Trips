using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sales.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        #region Navigation Properties

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set;}

        #endregion

        #region Constructors

        public Order() 
        {
            OrderDetails = new Collection<OrderDetail>();
        }

        #endregion
    }
}