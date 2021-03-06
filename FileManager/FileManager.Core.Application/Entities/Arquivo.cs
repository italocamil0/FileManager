using FileManager.Core.Application.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FileManager.Core.Application.Entities
{
    public class Arquivo : Entity
    {
        
        public Guid PrefixoId { get; set; }
        public Guid FrequenciaExecucaoId { get; set; }
        public string Tabela { get; set; }
        public string Esquema { get; set; }
        public IEnumerable<Campo> Campos { get; set; }
        public bool Posicional { get; set; }
        public string Divisor { get; set; }

        [MaxLength(128), ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Prefixo Prefixo { get; set; }
        public FrequenciaExecucao FrequenciaExecucao { get; set; }
        public string DiaDaSemana { get; set; }
        public int? Dia1 { get; set; }
        public int? Dia2 { get; set; }
        public string Horario { get; set; }
        //public DetalheArquivoFrequencia DetalheArquivoFrequencia { get; set; }
    }
}
