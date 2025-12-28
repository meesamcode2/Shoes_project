using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes_project.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title is Required")]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact is Required")]
        [Phone]
        [StringLength(11)]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is Required")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is Required")]
        [Range(0, 1000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Hire Date is Required")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency Contact is Required")]
        public string EmergencyContact { get; set; } = string.Empty;
    }
}