using System;
using System.ComponentModel.DataAnnotations;

namespace Shoes_project.Models
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 100)]
        public decimal DiscountPercentage { get; set; } = 0;

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(7);
    }
}