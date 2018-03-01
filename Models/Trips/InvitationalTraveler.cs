using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trips.Models
{
    [Table("InvitationalTravelers", Schema = "dbo")]
    public class InvitationalTraveler : _StatusCreateUpdate
    {
        [Key]
        public int InvitationalTravelerId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string FirstName { get; set; }
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string LastName { get; set; }
        [MaxLength(30, ErrorMessage = "Cannot exceed 30 characters")]
        public string ContactPhone { get; set; }
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string ContactEmail { get; set; }
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string OrganizationName { get; set; }
        [MaxLength(30, ErrorMessage = "Cannot exceed 30 characters")]
        public string OrganizationPhone { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool IsActive { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}{2}", FirstName, String.IsNullOrEmpty(MiddleName) ? "" : MiddleName + " ", LastName); // Don't include Middle Name if empty/null
            }
        }

        [NotMapped]
        public string FullNameLegal
        {
            get
            {
                return String.Format("{0} {1}{2}", FirstName, String.IsNullOrEmpty(MiddleName) ? "" : MiddleName + " ", LastName); // Don't include Middle Name if empty/null
            }
        }

        [NotMapped]
        public bool InUse
        {
            get
            {
                return false; //TBD: to implement logic for in-use when trips are created
            }
        }

        #endregion

        #region Navigation Properties

        [ForeignKey("DivisionId")]
        public Division Division { get; set; }

        #endregion
    }
}
