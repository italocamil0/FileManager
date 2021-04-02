using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Business.Models
{
    public class FrequenciaExecucao : Entity
    {
        public string Frequencia { get; set; }

        public Arquivo Arquivo { get; set; }
    }
}
