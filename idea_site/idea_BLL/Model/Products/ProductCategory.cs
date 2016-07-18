using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model
{
    [Table("tblProductCategory")]
    public class ProductCategory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdCategoryID { get; set; }

        [Required]
        public string ProdCategoryName { get; set; }

        public string ProdCategoryImage { get; set; }


        public virtual List<Product> Products { get; set; }
    }
}