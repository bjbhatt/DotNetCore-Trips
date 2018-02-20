using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("Countries", Schema = "dbo")]
    public class Country
    {
        [Key]
        [MaxLength(10)]
        public string ShortName { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }

    }
}
