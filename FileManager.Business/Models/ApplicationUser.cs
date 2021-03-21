using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Business.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Arquivo> Arquivos { get; set; }
    }
}
