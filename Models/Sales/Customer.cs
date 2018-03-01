using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Models
{
    //[Table("Customers", Schema = "dbo")]
    public class Customer
    {
        //[Key]
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
}