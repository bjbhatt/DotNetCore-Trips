using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("Priority", Schema = "dbo")]
    public class Priority : _StatusCreateUpdate
    {
        [Key]
        public int PriorityId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128)]
        public string Description { get; set; }
        public bool IncludeInSummary { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public string Display
        {
            get
            {
                return string.Format("{0} - {1}", PriorityId, Description);
            }
        }

        #endregion
    }
}
