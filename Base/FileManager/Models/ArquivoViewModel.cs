using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Models
{
    public class ArquivoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Frequencia")]
        public Guid FrequenciaExecucaoId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tabela { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Esquema { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Prefixo { get; set; }
        public IEnumerable<CampoViewModel> Campos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Posicional { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 1)]
        public string Divisor { get; set; }
        
        public DateTime DiaExecucao1 { get; set; }
        
        public DateTime DiaExecucao2 { get; set; }

        [DisplayName("Frequência")]
        public FrequenciaExecucaoViewModel FrequenciaExecucao { get; set; }

        public IEnumerable<FrequenciaExecucaoViewModel> FrequenciasExecucao { get; set; }
    }
}
