using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.App.WebApp.Models
{
    public class CampoViewModel
    {
        
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Tamanho { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tipo { get; set; }
        public DateTime DataRegistro { get; set; }

        /* EF Relations */
        public ArquivoViewModel Arquivo { get; set; }
    }
}
