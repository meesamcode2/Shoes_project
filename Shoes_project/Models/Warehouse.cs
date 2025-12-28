using System.ComponentModel.DataAnnotations;

namespace Shoes_project.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        public string? ManagerName { get; set; }

        public string? ContactNumber { get; set; }
    }
}