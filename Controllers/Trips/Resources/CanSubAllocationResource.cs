using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class CanSubAllocationResource
    {
        public int CanSubAllocationId { get; set; }
        public int CanAllocationId { get; set; }
        public string NEDId { get; set; }
        [Range(0.00, 10000000.00, ErrorMessage = "Must be between 0 and 10,000,000")]
        [DisplayName("Travel Amount")]
        public decimal? TravelAmount { get; set; }
        [Range(0.00, 10000000.00, ErrorMessage = "Must be between 0 and 10,000,000")]
        [DisplayName("Registration Amount")]
        public decimal? POTSAmount { get; set; }
        [Range(0.00, 10000000.00, ErrorMessage = "Must be between 0 and 10,000,000")]
        public bool InUse { get; set; }

        #region Referenced Resources

        public UserResource User { get; set; }

        public CanAllocationSummaryResource CanAllocation { get; set; }

        #endregion

        #region ReadOnly Properties

        public decimal Total
        {
            get
            {
                return (this.TravelAmount ?? 0) + (this.POTSAmount ?? 0);
            }
        }

        public CanSummaryResource Can
        {
            get
            {
                return this.CanAllocation == null ? null : this.CanAllocation.Can;
            }
        }

        #endregion

    }
}
