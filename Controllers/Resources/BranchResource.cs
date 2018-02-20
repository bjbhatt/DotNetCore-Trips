using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class BranchResource
    {
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [DisplayName("NIH SAC"), MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string NIHSAC { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Description"), MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [DisplayName("Short Name"), Required(ErrorMessage = "Required"), MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string ShortName { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
        public bool InUse { get; set; }
        [DisplayName("Active Until")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime? ActiveUntil { get; set; }

        #region Referenced Resources

        public DivisionSummaryResource Division { get; set; }

        #endregion
    }

    public class BranchSummaryResource 
    {
        public int BranchId { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
        public DivisionSummaryResource Division { get; set; }
    }
}
