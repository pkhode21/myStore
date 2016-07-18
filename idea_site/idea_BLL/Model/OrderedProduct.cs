using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model
{
    [Table("tblOrderedProduct")]
    public class OrderedProduct
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderedProductID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderID")]
        public virtual CustOrder Order { get; set; }
    }
}