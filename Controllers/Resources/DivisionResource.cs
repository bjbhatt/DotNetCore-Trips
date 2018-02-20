using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class DivisionResource
    {
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int InstituteId { get; set; }
        public string NIHSAC { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        [Display(Description = "Short Name")]
        public string ShortName { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
        [Range(-30, 30, ErrorMessage = "Must be between -30 and 30")]
        public int? DefaultTravelStartOffset { get; set; }
        [Range(-30, 30, ErrorMessage = "Must be between -30 and 30")]
        public int? DefaultLodgeOffset { get; set; }
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100")]
        public int? DefaultMealFirstPercent { get; set; }
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100")]
        public int? DefaultMealLastPercent { get; set; }
        [Range(0, 10000, ErrorMessage = "Must be between 0 and 10,000")]
        public int? DefaultOtherRate { get; set; }
        public bool? IsLocked { get; set; }
        public int? FiscalYearLock { get; set; }
        public bool InUse { get; set; }

        #region Referenced Resources

        public InstituteSummaryResource Institute { get; set; }

        #endregion
    }

    public class DivisionSummaryResource 
    {
        public int DivisionId { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
        public InstituteSummaryResource Institute { get; set; }
    }
}
