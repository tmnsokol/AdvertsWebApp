using System.ComponentModel.DataAnnotations;

namespace AdWebApp.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not compared.")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }
    }
}