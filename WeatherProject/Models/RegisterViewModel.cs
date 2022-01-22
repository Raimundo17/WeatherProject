using System.ComponentModel.DataAnnotations;
using WeatherProject.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace WeatherProject.Models
{
    public class RegisterViewModel : User
    {
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
