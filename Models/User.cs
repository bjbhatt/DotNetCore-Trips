using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    [Table("Users", Schema = "dbo")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(25)]
        public string NEDId { get; set; }
        [MaxLength(25)]
        public string LoginId { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string MiddleName { get; set; }
        [MaxLength(255)]
        public string SignatureName { get; set; }
        [MaxLength(255)]
        public string FullName { get; set; }
        [MaxLength(255)]
        public string FullNameLegal { get; set; }
        [MaxLength(255)]
        public string EMail { get; set; }
        [MaxLength(255)]
        public string AppointmentType { get; set; }
        [MaxLength(255)]
        public string PositionTitle { get; set; }
        [MaxLength(255)]
        public string JobTitle { get; set; }
        [MaxLength(25)]
        public string InstituteShortName { get; set; }
        [MaxLength(25)]
        public string DivisionShortName { get; set; }
        [MaxLength(25)]
        public string BranchShortName { get; set; }
        [MaxLength(255)]
        public string NIH_ORG_PATH { get; set; }
        [MaxLength(25)]
        public string NIHSAC { get; set; }
        [MaxLength(25)]
        public string SupervisorNEDId { get; set; }
        [MaxLength(255)]
        public string SupervisorName { get; set; }
        public Status Status { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public string Title
        {
            get
            {
                return !string.IsNullOrWhiteSpace(PositionTitle) ? PositionTitle : !string.IsNullOrWhiteSpace(JobTitle) ? JobTitle : AppointmentType;
            }
        }

        #endregion

        #region Navigation Properties

        //public ICollection<UserRole> UserRoles { get; set; }   **Leave this oen out it is creating a circular reference because of many to many relationship**

        #endregion
    }
}
