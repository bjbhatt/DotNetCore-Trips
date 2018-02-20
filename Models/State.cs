using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("State", Schema = "dbo")]
    public class State
    {
        [Key]
        [MaxLength(10)]
        public string ShortName { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }

    }
}
