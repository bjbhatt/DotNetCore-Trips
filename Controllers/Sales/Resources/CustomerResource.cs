using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sales.Controllers.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }

        public ICollection<OrderResource> Orders { get; set;}

        public CustomerResource() 
        {
            Orders = new Collection<OrderResource>();
        }
    }
}