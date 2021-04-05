using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.App.WebApp.Models
{
    public class FrequenciaExecucaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Frequencia { get; set; }

        public string DiaDaSemana { get; set; }

        
        public int Dia1 { get; set; }
        
        public int Dia2 { get; set; }
        public string Horario { get; set; }


        public ArquivoViewModel Arquivo { get; set; }
    }
}
