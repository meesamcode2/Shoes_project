using System.ComponentModel.DataAnnotations;

namespace Shoes_project.Models
{
    public class MembershipLevel
    {
        [Key]
        public int MembershipLevelId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;   // Bronze, Silver, Gold

        [Required]
        public decimal DiscountPercentage { get; set; }   // e.g. 5, 10, 15

        [Required]
        public decimal MinimumSpend { get; set; }          // eligibility

        public string? Benefits { get; set; }              // description
    }
}