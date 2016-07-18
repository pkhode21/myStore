using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model
{
    [Table("tblCustOrder")]
    public class CustOrder
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderPlacedDate { get; set; }

        [Required]
        public bool IsUrgent { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}