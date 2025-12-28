using System.ComponentModel.DataAnnotations;

namespace Shoes_project.Models
{
    public class MembershipLevel
    {
        [Key]
        public int MembershipLevelId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;   

        [Required]
        public decimal DiscountPercentage { get; set; }   

        [Required]
        public decimal MinimumSpend { get; set; }
        [Required]
        public string? Benefits { get; set; }             
    }
}