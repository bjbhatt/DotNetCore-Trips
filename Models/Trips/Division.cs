using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trips.Models
{
    [Table("Divisions", Schema = "dbo")]
    public class Division : _StatusCreateUpdate
    {
        [Key]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int InstituteId { get; set; }
        public string NIHSAC { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string ShortName { get; set; }
        [Range(-30, 30, ErrorMessage = "Must be between -30 and 30")]
        public int DefaultTravelStartOffset { get; set; }
        [Range(-30, 30, ErrorMessage = "Must be between -30 and 30")]
        public int DefaultLodgeOffset { get; set; }
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100")]
        public int DefaultMealFirstPercent { get; set; }
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100")]
        public int DefaultMealLastPercent { get; set; }
        [Range(0, 10000, ErrorMessage = "Must be between 0 and 10,000")]
        public int DefaultOtherRate { get; set; }
        public bool IsLocked { get; set; }
        public int FiscalYearLock { get; set; }

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
                return (Branches.Count(b => b.Status == Status.Active) != 0) ||
                    (Cans.Count(b => b.Status == Status.Active) != 0) ||
                    (CanAllocations.Count(b => b.Status == Status.Active) != 0);
            }
        }

        #endregion

        #region Navigation Properties

        [ForeignKey("InstituteId")]
        public Institute Institute { get; set; }

        public ICollection<Branch> Branches { get; set; }

        public ICollection<Can> Cans { get; set; }

        public ICollection<CanAllocation> CanAllocations { get; set; }

        #endregion

        #region Constructor

        public Division()
        {
            Branches = new Collection<Branch>();
            Cans = new Collection<Can>();
            CanAllocations = new Collection<CanAllocation>();
        }

        #endregion
    }
}
