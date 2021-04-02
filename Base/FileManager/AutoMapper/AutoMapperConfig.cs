using AutoMapper;
using FileManager.Business.Models;
using FileManager.Models;

namespace FileManager.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FrequenciaExecucao, FrequenciaExecucaoViewModel>().ReverseMap();
            CreateMap<Campo, CampoViewModel>().ReverseMap();
            CreateMap<Arquivo, ArquivoViewModel>().ReverseMap();                        
        }
    }
}
