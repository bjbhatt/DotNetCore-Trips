using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    //[Table("Orders", Schema = "dbo")]
    public class Order
    {
        //[Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public DateTime? UpdateTimeStamp { get; set; }

        #region Navigation Properties

        //[ForeignKey("CustomerId")]
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