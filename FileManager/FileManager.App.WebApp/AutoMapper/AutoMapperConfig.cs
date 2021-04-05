using AutoMapper;
using FileManager.App.WebApp.Models;
using FileManager.Core.Application.DTOs;

namespace FileManager.App.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Prefixo, PrefixoViewModel>().ReverseMap();
            CreateMap<FrequenciaExecucao, FrequenciaExecucaoViewModel>().ReverseMap();
            CreateMap<Campo, CampoViewModel>().ReverseMap();
            CreateMap<Arquivo, ArquivoViewModel>().ReverseMap();
        }
    }
}
