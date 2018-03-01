using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trips.Models
{
    public abstract class _Status
    {
        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime StatusUpdateDateTime { get; set; }

        [Required]
        public string StatusUpdateUserNEDId { get; set; }

        #region Navigation Properties

        [ForeignKey("StatusUpdateUserNEDId")]
        public User StatusUpdateUser { get; set; }

        #endregion
    }


    public abstract class _StatusCreateUpdate : _Status
    {
        [Required]
        public DateTime CreateDateTime { get; set; }

        [Required]
        [MaxLength(25)]
        public string CreateUserNEDId { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

        [MaxLength(25)]
        public string LastUpdateUserNEDId { get; set; }

        #region Navigation Properties

        [ForeignKey("CreateUserNEDId")]
        public User CreateUserInfo { get; set; }

        [ForeignKey("LastUpdateUserNEDId")]
        public User LastUpdateUserInfo { get; set; }

        #endregion
    }


}
