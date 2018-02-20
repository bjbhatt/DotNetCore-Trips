using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("UserRoles", Schema = "dbo")]
    public class UserRole : _StatusCreateUpdate
    {
        [Key]
        public int UserRoleId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(25)]
        public string NEDId { get; set; }
        [Required(ErrorMessage = "Required")]
        public RoleEnum RoleId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int OrganizationId { get; set; }

        [NotMapped]
        public Institute Institute { get; set; }
        [NotMapped]
        public Division Division { get; set; }
        [NotMapped]
        public Branch Branch { get; set; }

        #region Navigation Properties

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("NEDId")]
        public User User { get; set; }

        #endregion
    }
}
