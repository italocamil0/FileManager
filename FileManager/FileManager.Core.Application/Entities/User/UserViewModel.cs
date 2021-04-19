using System.ComponentModel.DataAnnotations;

namespace FileManager.Core.Application.Entities.User
{
    public class UserViewModel
    {
        [Display(Name = "Cod.")]
        public string Id { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Usuário")]
        public string UserName { get; set; }
    }
}
