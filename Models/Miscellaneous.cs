using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("Miscellaneous", Schema = "dbo")]
    public class Miscellaneous : _StatusCreateUpdate
    {
        [Key]
        public int MiscellaneousId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Module { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Key { get; set; }
        [MaxLength(2000, ErrorMessage = "Cannot exceed 2000 characters")]
        public string Value { get; set; }
    }
}
