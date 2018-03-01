using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    public class CanAllocation : _StatusCreateUpdate
    {
        [Key]
        public int CanAllocationId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int FiscalYear { get; set; }
        [Required(ErrorMessage = "Required")]
        public int CanId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int BranchId { get; set; }
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

        [ForeignKey("DivisionId")]
        public Division Division { get; set; }

        [ForeignKey("CanId")]
        public Can Can { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public ICollection<CanSubAllocation> CanSubAllocations { get; set; }

        #endregion

        #region Constructor

        public CanAllocation()
        {
            CanSubAllocations = new Collection<CanSubAllocation>();
        }

        #endregion
    }
}
