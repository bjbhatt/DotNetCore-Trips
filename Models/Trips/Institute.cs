using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trips.Models
{
    [Table("Institutes", Schema = "dbo")]
    public class Institute : _StatusCreateUpdate
    {
        [Key]
        public int InstituteId { get; set; }
        [Required(ErrorMessage = "Required")]
        [MaxLength(128, ErrorMessage = "Cannot exceed 128 characters")]
        public string Description { get; set; }
        [MaxLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string ShortName { get; set; }

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

        [NotMapped]
        public bool InUse
        {
            get
            {
                return Divisions != null ? Divisions.Count(d => d.Status == Status.Active) != 0 : false;
            }
        }

        #endregion

        #region Navigation Properties

        public ICollection<Division> Divisions { get; set; }

        #endregion

        #region Constructor

        public Institute()
        {
            Divisions = new Collection<Division>();
        }
        
        #endregion
        
    }
}