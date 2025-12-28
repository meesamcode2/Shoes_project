using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes_project.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }

        [Required]
        public int OrderId { get; set; }  // Foreign key

        [ForeignKey("OrderId")]
        public Order? Order { get; set; } // Navigation property nullable

        [Required]
        public string DeliveryStatus { get; set; } = "Pending";

        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; } = DateTime.Today;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Courier { get; set; } = string.Empty;
    }
}