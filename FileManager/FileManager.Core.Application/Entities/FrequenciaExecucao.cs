using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Core.Application.Entities
{
    public class FrequenciaExecucao : Entity
    {
        public string Frequencia { get; set; }
        
        public IEnumerable<DetalheArquivoFrequencia> DetalhesArquivoFrequencia { get; set; }
    }
}
