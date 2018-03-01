using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class TravelTypeResource
    {
        public int TravelTypeId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Travel Type"), MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }

        public string Display { get; set; }
    }
}
