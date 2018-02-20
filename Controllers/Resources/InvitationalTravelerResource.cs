using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trips.Controllers.Resources
{
    public class InvitationalTravelerResource
    {
        public int InvitationalTravelerId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [DisplayName("First Name"), Required(ErrorMessage = "Required"), MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name"), MaxLength(255,ErrorMessage="Cannot exceed 255 characters")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name"), Required(ErrorMessage = "Required"), MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string LastName { get; set; }
        [DisplayName("Contact Phone"), MaxLength(30,ErrorMessage="Cannot exceed 30 characters")]
        public string ContactPhone { get; set; }
        [DisplayName("Contact Email"), MaxLength(255,ErrorMessage="Cannot exceed 255 characters")]
        public string ContactEmail { get; set; }
        [DisplayName("Organization Name"), MaxLength(255,ErrorMessage="Cannot exceed 255 characters")]
        public string OrganizationName { get; set; }
        [DisplayName("Organization Phone"), MaxLength(30,ErrorMessage="Cannot exceed 30 characters")]
        public string OrganizationPhone { get; set; }
        [DisplayName("Is Active?"), Required(ErrorMessage="Required")]
        public bool IsActive { get; set; }
        public bool InUse { get; set; }
        public string FullName { get; set; }
        public string FullNameLegal { get; set; }

        #region Referenced Resources

        public DivisionSummaryResource Division { get; set; }

        #endregion
    }
}
