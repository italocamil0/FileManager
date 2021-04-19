using System;

namespace FileManager.Core.Application.Entities
{
    public class DetalheArquivoFrequencia : Entity
    {

        public Guid ArquivoId { get; set; }

        public Guid FrequenciaExecucaoId { get; set; }

        public  string DiaDaSemana { get; set; }

        public int? Dia1 { get; set; }

        public int? Dia2 { get; set; }

        public string Horario { get; set; }

        public Arquivo Arquivo { get; set; }

        public FrequenciaExecucao FrequenciasExecucao { get; set; }
    }
}
