using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idea_BLL.Model
{
    [Table("tblProductComment")]
    public class ProductComment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdCommentID { get; set; }

        [Required]
        public string ProdFeedback { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        public decimal StarRating { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }
    }
}