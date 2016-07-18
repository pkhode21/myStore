using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model.User
{
    [Table("tblUserType")]
    public class UserType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTypeID { get; set; }

        [Required]
        public string UserTypeName { get; set; }
    }
}