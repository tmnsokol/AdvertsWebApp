using System.ComponentModel.DataAnnotations;

namespace AdWebApp.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password:")]

        public string Password { get; set; }
    }
}