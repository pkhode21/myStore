using idea_BLL.Model.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model.User
{
    [Table("tblStore")]
    public class Store
    {
        [Key,ForeignKey("User")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreID { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string StoreAddress { get; set; }

        [Required]
        public int CityID { get; set; }

        [ForeignKey("CityID")]
        public virtual City City { get; set; }

        public virtual User User { get; set; }
    }
}