using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherProject.Models
{
    public class LoginViewModel 
    {

        public string Email { get; set; }

        [Required]
        [MinLength(6)] //só funciona para a view (para dar as mensagens ao utilizador)
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
