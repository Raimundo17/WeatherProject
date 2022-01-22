using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WeatherProject.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string LastName { get; set; }

        public string ImageUrl { get; set; } // Link das imagens

        //public Guid ImageId { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return null;
                }

                return $"https://localhost:44328{ImageUrl.Substring(1)}"; // quando tiver no azure colocar o endereço completo
            }
        }

        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"https://projetooficinaweb20211019102411.azurewebsites.net/images/noimage.png"
        //    : $"https://projetooficinaweb.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
