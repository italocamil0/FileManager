using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Core.Application.DTOs
{
    public class FrequenciaExecucao : Entity
    {
        public string Frequencia { get; set; }

        public string DiaDaSemana { get; set; }

        public int Dia1 { get; set; }
        public int Dia2 { get; set; }
        public string Horario { get; set; }

        public Arquivo Arquivo { get; set; }
    }
}
