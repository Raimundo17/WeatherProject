using System.ComponentModel.DataAnnotations;

namespace WeatherProject.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
