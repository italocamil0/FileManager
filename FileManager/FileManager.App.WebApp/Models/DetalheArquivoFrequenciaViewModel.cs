using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.App.WebApp.Models
{
    public class DetalheArquivoFrequenciaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ArquivoId { get; set; }

        public Guid FrequenciaExecucaoId { get; set; }

        public string DiaDaSemana { get; set; }

        public int? Dia1 { get; set; }

        public int? Dia2 { get; set; }

        public string Horario { get; set; }        

        public FrequenciaExecucaoViewModel FrequenciasExecucao { get; set; }
    }
}
