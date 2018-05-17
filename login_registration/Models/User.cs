using System.ComponentModel.DataAnnotations;

namespace login_registration.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string First_Name { get; set; }

        [Required]
        [MinLength(2)]
        public string Last_Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}