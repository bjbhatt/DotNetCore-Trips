using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class CanResource
    {
        public int CanId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("CAN Number"), MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string CanNumber { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("CAN Description"), MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Reimbursable")]
        public bool Reimbursable { get; set; }
        [DisplayName("Project Number"), MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string ProjectNumber { get; set; }
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

    public class CanSummaryResource 
    {
        public int CanId { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
        public DivisionSummaryResource Division { get; set; }
    }
}
