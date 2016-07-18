using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdID { get; set; }

        [Required]
        public string ProdName { get; set; }

        public string ProdDescription { get; set; }

        [Required]
        public decimal ProdCost { get; set; }

        public string ProdImage { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public int ProdCategoryID { get; set; }

        [Required]
        public string ProdCompany { get; set; }

        public string ProdModelNumber { get; set; }

        [ForeignKey("ProdCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}