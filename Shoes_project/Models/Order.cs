using System;
using System.ComponentModel.DataAnnotations;

namespace Shoes_project.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public string CustomerPhone { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
    }
}