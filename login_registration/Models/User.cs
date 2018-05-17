using System;
using System.ComponentModel.DataAnnotations;

namespace login_registration.Models
{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    {
        [Required(ErrorMessage = "First name is required")]
        [MinLength(2)]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2)]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MinLength(5, ErrorMessage = "Email address is too short")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be longer than 4 characters")]
        public string Password { get; set; }
    }
}