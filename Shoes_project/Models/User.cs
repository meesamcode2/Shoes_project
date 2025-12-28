using System.ComponentModel.DataAnnotations;

namespace Shoes_project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Range(0, 2)]
        public int AccessLevel { get; set; } // 0 = Owner, 1 = Manager, 2 = Guest
    }
}