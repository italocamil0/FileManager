using AutoMapper;
using FileManager.App.WebApp.Models;
using FileManager.Core.Application.Entities;

namespace FileManager.App.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            
            //CreateMap<DetalheArquivoFrequencia, DetalheArquivoFrequenciaViewModel>().ReverseMap();
            CreateMap<FrequenciaExecucao, FrequenciaExecucaoViewModel>().ReverseMap();
            CreateMap<Prefixo, PrefixoViewModel>().ReverseMap();
            CreateMap<Campo, CampoViewModel>().ReverseMap();
            CreateMap<Arquivo, ArquivoViewModel>().ReverseMap();
        }
    }
}
