using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class InstituteResource
    {
        public int InstituteId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string ShortName { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
        public bool InUse { get; set; }
    }

    public class InstituteSummaryResource 
    {
        public int InstituteId { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
    }
}
