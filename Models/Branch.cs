using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trips.Models
{
    [Table("Branches", Schema = "dbo")]
    public class Branch : _StatusCreateUpdate
    {
        [Key]
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string NIHSAC { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string ShortName { get; set; }
        public DateTime? ActiveUntil { get; set; }

        #region Unmapped Read-only Properties

        [NotMapped]
        public string Display
        {
            get
            {
                return string.IsNullOrWhiteSpace(NIHSAC) ? string.Format("{0} - {1}", ShortName, Description) : string.Format("{0} - {1} ({2})", ShortName, Description, NIHSAC);
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

        public Branch()
        {
            CanAllocations = new Collection<CanAllocation>();
        }

        #endregion
    }
}
