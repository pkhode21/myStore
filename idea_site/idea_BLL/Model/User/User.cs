using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model.User
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        [Required]
        [StringLength(25)]
        [Index("UIX_UserEmailAddress",1,IsUnique = true)]
        public string UserEmailAddress { get; set; }

        [Required]
        public string UserPassword { get; set; }

        /*1 - Merchant , 2 - Customer*/
        [Required]
        public int UserTypeID { get; set; }

        [Required]
        public DateTime LatestLoggedIn { get; set; }

        [Required]
        public bool IsAccountVerified { get; set; }

        public string UserProfilePicPath { get; set; }

        [ForeignKey("UserTypeID")]
        public virtual UserType UserType { get; set; }
    }
}