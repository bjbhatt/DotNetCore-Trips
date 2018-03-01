using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trips.Models
{
    [Table("Cans", Schema = "dbo")]
    public class Can : _StatusCreateUpdate
    {
        [Key]
        public int CanId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string CanNumber { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public bool Reimbursable { get; set; }
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string ProjectNumber { get; set; }
        public DateTime? ActiveUntil { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public string Display
        {
            get
            {
                return string.Format("{0} - {1}{2}", CanNumber, Description, Reimbursable ? " *REIMB*" : "");
            }
        }

        [NotMapped]
        public string DisplayShort
        {
            get
            {
                return string.Format("{0}", CanNumber);
            }
        }

        [NotMapped]
        public bool InUse
        {
            get
            {
                return CanAllocations != null ? CanAllocations.Count(cb => cb.Status == Status.Active) != 0 : false;
            }
        }

        #endregion

        #region Navigation Properties

        [ForeignKey("DivisionId")]
        public Division Division { get; set; }

        public ICollection<CanAllocation> CanAllocations { get; set; }

        #endregion

        #region Constructor

        public Can()
        {
            CanAllocations = new Collection<CanAllocation>();
        }

        #endregion

    }
}
