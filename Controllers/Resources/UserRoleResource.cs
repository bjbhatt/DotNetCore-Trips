using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Trips.Models;

namespace Trips.Controllers.Resources
{
    public class UserRoleResource
    {
        public int UserRoleId { get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "Required")]
        public RoleEnum RoleId { get; set; }
        [DisplayName("NED Id")]
        [Required(ErrorMessage = "User Name must be selected from the list")]
        public string NEDId { get; set; }
        [DisplayName("Organization")]
        [Required(ErrorMessage = "Required")]
        public int OrganizationId { get; set; }

        #region Referenced Resources

        public RoleResource Role { get; set; }

        public UserResource User { get; set; }

        public InstituteResource Institute { get; set; }

        public DivisionResource Division { get; set; }

        public BranchResource Branch { get; set; }

        #endregion

        public string OrganizationDisplay
        {
            get
            {
                return Institute != null ? "Institute" : Division != null ? "Division: " + Division.Display : Branch != null ? "Branch: " + Branch.Display : "(unknown)";
            }
        }

        public string OrganizationDisplayShort
        {
            get
            {
                return Institute != null ? "Institute" : Division != null ? "Division: " + Division.DisplayShort : Branch != null ? "Branch: " + Branch.DisplayShort : "(unknown)";
            }
        }
    }
}
