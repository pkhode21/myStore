using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model.User
{
    [Table("tblUserToken")]
    public class UserToken
    {
        [Key]
        [Required]
        public Guid TokenID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        /*TokenType = 1 means Email Verification*/
        /*TokenType = 2 means Reset Password*/
        public int TokenType { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
