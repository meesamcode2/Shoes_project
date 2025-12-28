using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes_project.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string MembershipStatus { get; set; } 

        [Required]
        public decimal TotalSpend { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
    }
}
