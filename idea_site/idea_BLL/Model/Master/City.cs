using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model.Master
{
    [Table("tblCity")]
    public class City
    {
        [Key]
        [Required]
        public int CityID { get; set; }

        [Required]
        [StringLength(25)]
        [Index("UIX_CityName",1,IsUnique =true)]
        public string CityName { get; set; }

        [Required]
        [StringLength(10)]
        [Index("UIX_PinCode",1,IsUnique = true)]
        public string PinCode { get; set; }
    }
}