using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Core.Application.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Arquivo> Arquivos { get; set; }
    }
}
