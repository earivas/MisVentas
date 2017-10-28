using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MisVentas.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="  El Usuario es obligatorio")]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "  La Contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}