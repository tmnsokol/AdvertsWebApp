using System.ComponentModel.DataAnnotations;

namespace AdWebApp.Models
{
    public class AdvertViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content:")]
        public string Content { get; set; }

        public ClientProfileModel ClientProfile  { get; set; }
    }
}