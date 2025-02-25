using ApiParaLocalizarTransporte.DTOS.LinhaDTOs;
using ApiParaLocalizarTransporte.DTOS.ParadaDTOs;
using ApiParaLocalizarTransporte.DTOS.PosicaoVeiculoDTOs;
using ApiParaLocalizarTransporte.DTOS.VeiculoDTOs;
using ApiParaLocalizarTransporte.Models;
using AutoMapper;

namespace ApiParaLocalizarTransporte.DTOS.MappingDTO
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

            CreateMap<Veiculo, VeiculoResponseDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoCreateDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoUpdateRequestDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoComLinhaResponseDTO>().ReverseMap();

            CreateMap<PosicaoVeiculo, PosicaoVeiculoResponseDTO>().ReverseMap();
            CreateMap<PosicaoVeiculo, PosicaoVeiculoCreateDTO>().ReverseMap();
            CreateMap<PosicaoVeiculo, PosicaoVeiculoUpdateRequestDTO>().ReverseMap();
        }
    }
}
