using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class MiscellaneousResource
    {
        public int MiscellaneousId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Module { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
