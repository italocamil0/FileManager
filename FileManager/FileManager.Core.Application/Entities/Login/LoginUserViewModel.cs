using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FileManager.Core.Application.Entities.Login
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "E-mail é requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
