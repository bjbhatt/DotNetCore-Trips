using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class CanAllocationResource
    {
        public int CanAllocationId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Division")]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Fiscal Year")]
        public int FiscalYear { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("CAN")]
        public int CanId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Branch")]
        public int BranchId { get; set; }
        [Range(0.00, 10000000.00, ErrorMessage = "Must be between 0 and 10,000,000")]
        [DisplayName("Travel Amount")]
        public decimal? TravelAmount { get; set; }
        [Range(0.00, 10000000.00, ErrorMessage = "Must be between 0 and 10,000,000")]
        [DisplayName("POTS Amount")]
        public decimal? POTSAmount { get; set; }
        public bool InUse { get; set; }

        #region Referenced Resources

        public DivisionSummaryResource Division { get; set; }

        public CanSummaryResource Can { get; set; }

        public BranchSummaryResource Branch { get; set; }

        #endregion

        #region ReadOnly Properties

        public decimal Total
        {
            get
            {
                return (this.TravelAmount ?? 0) + (this.POTSAmount ?? 0);
            }
        }

        #endregion
    }

    public class CanAllocationSummaryResource 
    {
        public int CanAllocationId { get; set; }
        public int FiscalYear { get; set; }
        public decimal? TravelAmount { get; set; }
        public decimal? POTSAmount { get; set; }
        public DivisionSummaryResource Division { get; set; }
        public CanSummaryResource Can { get; set; }
        public BranchSummaryResource Branch { get; set; }
    }
}
