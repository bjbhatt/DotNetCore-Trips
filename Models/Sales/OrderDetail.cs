//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{

    //[Table("OrderDetails", Schema = "dbo")]
    public class OrderDetail
    {
        //[Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        #region Navigation Properties

        //[ForeignKey("OrderId")]
        public Order Order { get; set; }
        //[ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion

        #region Constructors

        // No Constructor needed
        
        #endregion
    }
}