using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes_project.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public string SKU { get; set; } = string.Empty;

        [Required]
        public int WarrantyMonths { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Supplier { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
