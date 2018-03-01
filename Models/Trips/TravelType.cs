using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("TravelType", Schema = "dbo")]
    public class TravelType : _StatusCreateUpdate
    {
        [Key]
        public int TravelTypeId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128)]
        public string Description { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public string Display
        {
            get
            {
                return string.Format("{0}", Description);
            }
        }

        #endregion
    }
}
