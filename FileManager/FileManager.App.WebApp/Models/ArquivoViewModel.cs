﻿using System;
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

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Frequencia")]
        public Guid FrequenciaExecucaoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Prefixo")]
        public Guid PrefixoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tabela { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Esquema { get; set; }      

        public IEnumerable<CampoViewModel> Campos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Posicional { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 1)]
        public string Divisor { get; set; }

        [DisplayName("Frequência")]
        public FrequenciaExecucaoViewModel FrequenciaExecucao { get; set; }

        [DisplayName("Prefixo")]
        public PrefixoViewModel Prefixo { get; set; }

        public IEnumerable<FrequenciaExecucaoViewModel> FrequenciasExecucao { get; set; }
        public IEnumerable<PrefixoViewModel> Prefixos { get; set; }
    }
}