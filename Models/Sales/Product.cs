using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    //[Table("Products", Schema = "dbo")]
    public class Product
    {
        //[Key]
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