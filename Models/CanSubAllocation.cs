using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("CanSubAllocations", Schema = "dbo")]
    public class CanSubAllocation : _StatusCreateUpdate
    {
        [Key]
        public int CanSubAllocationId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int CanAllocationId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(25)]
        public string NEDId { get; set; }
        [Range(0.00, 10000000.00, ErrorMessage = "Must be between 0 and 10,000,000")]
        public decimal? TravelAmount { get; set; }
        [Range(0.00, 10000000.00, ErrorMessage = "Must be between 0 and 10,000,000")]
        public decimal? POTSAmount { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public bool InUse
        {
            get
            {
                return false; //TBD: to implement logic for in-use when trips are created
            }
        }

        #endregion

        #region Navigation Properties

        [ForeignKey("CanAllocationId")]
        public CanAllocation CanAllocation { get; set; }

        [ForeignKey("NEDId")]
        public User User { get; set; }

        #endregion
    }
}
