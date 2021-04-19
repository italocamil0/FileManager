using System.ComponentModel.DataAnnotations;

namespace FileManager.Core.Application.Entities.User
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "E-mail é requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmação senha é requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
