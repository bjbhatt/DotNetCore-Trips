using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class CountryResource
    {
        public string ShortName { get; set; }
        public string Description { get; set; }

    }
}
