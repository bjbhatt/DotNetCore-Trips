using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("Roles", Schema = "dbo")]
    public class Role : _StatusCreateUpdate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        [Required(ErrorMessage = "Required")]
        public bool IsAdmin { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool CanManageSelf { get; set; }

        public RoleEnum? ParentRoleId { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public string Display
        {
            get
            {
                return string.Format("{0} - {1}", ShortName, Description);
            }
        }

        [NotMapped]
        public string DisplayShort
        {
            get
            {
                return string.Format("{0}", ShortName);
            }
        }

        #endregion

        #region Navigation Properties

        [ForeignKey("ParentRoleId")]
        public virtual Role ParentRole { get; set; }


        //public virtual ICollection<UserRole> UserRoles { get; set; }   **Leave this oen out it is creating a circular reference because of many to many relationship**

        #endregion
    }
}
