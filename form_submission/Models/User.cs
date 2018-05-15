using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
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
        [Range(18,200)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}