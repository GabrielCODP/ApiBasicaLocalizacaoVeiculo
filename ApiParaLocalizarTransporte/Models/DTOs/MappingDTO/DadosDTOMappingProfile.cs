using ApiParaLocalizarTransporte.Models.DTOs.LinhaDTOs;
using ApiParaLocalizarTransporte.Models.DTOs.ParadaDTOs;
using AutoMapper;

namespace ApiParaLocalizarTransporte.Models.DTOs.MappingDTO
{
    public class DadosDTOMappingProfile : Profile
    {
        public DadosDTOMappingProfile()
        {
            CreateMap<Parada, ParadaResponseDTO>().ReverseMap();
            CreateMap<Parada, ParadaCreateDTO>().ReverseMap();
            CreateMap<Parada, ParadaUpdateRequestDTO>().ReverseMap();

            CreateMap<Linha, LinhaResponseDTO>().ReverseMap();
            CreateMap<Linha, LinhaCreateDTO>().ReverseMap();
            CreateMap<Linha, LinhaUpdateRequestDTO>().ReverseMap();
            CreateMap<Linha, LinhaEParadaResponseDTO>().ReverseMap();
        }
    }
}
