using System.ComponentModel.DataAnnotations;

namespace AdWebApp.Models
{
    public class ClientProfileModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email:")]
        public string Email { get; set; }
    }
}