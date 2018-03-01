using System.ComponentModel.DataAnnotations;
using Trips.Models;

namespace Trips.Controllers.Resources
{
    public class RoleResource
    {
        public RoleEnum RoleId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool InstituteLevel { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool DivisionLevel { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool BranchLevel { get; set; }
        public string Display { get; set; }
        public string DisplayShort { get; set; }
    }
}
