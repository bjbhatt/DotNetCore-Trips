using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{

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