using System.Collections.Generic;
using System.Collections.ObjectModel;

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
}