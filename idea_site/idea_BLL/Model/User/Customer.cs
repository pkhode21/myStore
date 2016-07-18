using System;
using System.ComponentModel.DataAnnotations;

namespace idea_BLL.Model.User
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerLocation { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public DateTime CustomerCreatedDate { get; set; }

        [Required]
        public DateTime CustomerLastActiveDate { get; set; }
    }
}