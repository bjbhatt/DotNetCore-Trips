using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }

        #region Navigation Properties

        public ICollection<Order> Orders { get; set;}

        #endregion

        #region Constructors

        public Customer() 
        {
            Orders = new Collection<Order>();
        }

        #endregion
    }

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

    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        #region Navigation Properties

        public Order Order { get; set; }
        public Product Product { get; set; }

        #endregion

        #region Constructors

        // No Constructor needed
        
        #endregion
    }
}