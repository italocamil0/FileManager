using FileManager.Core.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FileManager.Core.Application.DTOs
{
    public class Arquivo : Entity
    {
        public Guid FrequenciaExecucaoId { get; set; }
        public Guid PrefixoId { get; set; }
        public string Tabela { get; set; }
        public string Esquema { get; set; }
        public IEnumerable<Campo> Campos { get; set; }
        public bool Posicional { get; set; }

        public string Divisor { get; set; }


        [MaxLength(128), ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public FrequenciaExecucao FrequenciaExecucao { get; set; }
        public Prefixo Prefixo { get; set; }
    }
}
