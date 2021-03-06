using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.App.WebApp.Models
{
    public class ArquivoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [RegularExpression(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Frequencia")]
        public Guid? FrequenciaExecucaoId { get; set; }

        [RegularExpression(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Prefixo")]
        public Guid? PrefixoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tabela { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Esquema { get; set; }      

        public List<CampoViewModel> Campos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Posicional { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 1)]
        public string Divisor { get; set; }

        [DisplayName("Frequência")]
        public FrequenciaExecucaoViewModel FrequenciaExecucao { get; set; }

        [DisplayName("Prefixo")]
        public PrefixoViewModel Prefixo { get; set; }
        public string DiaDaSemana { get; set; }

        public int? Dia1 { get; set; }

        public int? Dia2 { get; set; }

        public string Horario { get; set; }

        public IEnumerable<FrequenciaExecucaoViewModel> FrequenciasExecucao { get; set; }

        //public DetalheArquivoFrequenciaViewModel DetalheArquivoFrequencia { get; set; }
        public IEnumerable<PrefixoViewModel> Prefixos { get; set; }

        public ArquivoViewModel()
        {
            Campos = new List<CampoViewModel>();
        }
    }
}
