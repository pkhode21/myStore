using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model
{
    [Table("tblProductStock")]
    public class ProductStock
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdStockID { get; set; }

        [Required]
        public Int64 ProdCount { get; set; }
    }
}