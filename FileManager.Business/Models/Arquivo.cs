using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileManager.Business.Models
{
    public class Arquivo : Entity
    {
        public Guid FrequenciaExecucaoId { get; set; }
        public string Tabela { get; set; }
        public string Esquema { get; set; }
        public string Prefixo { get; set; }
        public IEnumerable<Campo> Campos { get; set; }
        public bool Posicional { get; set; }
                
        public string Divisor { get; set; }        
        public DateTime DiaExecucao1 { get; set; }
        public DateTime DiaExecucao2 { get; set; }
        
        [MaxLength(128), ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public FrequenciaExecucao FrequenciaExecucao { get; set; }
    }
}
