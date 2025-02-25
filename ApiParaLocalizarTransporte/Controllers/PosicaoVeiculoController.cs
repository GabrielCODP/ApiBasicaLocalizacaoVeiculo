using ApiParaLocalizarTransporte.DTOS.ParadaDTOs;
using ApiParaLocalizarTransporte.DTOS.PosicaoVeiculoDTOs;
using ApiParaLocalizarTransporte.Filters;
using ApiParaLocalizarTransporte.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiParaLocalizarTransporte.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public class PosicaoVeiculoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PosicaoVeiculoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosicaoVeiculoResponseDTO>>> GetPosicaoVeiculos()
        {
            var posicaoVeiculo = await _unitOfWork.PosicaoVeiculoRepository.GetAllAsync();

            if (posicaoVeiculo == null)
            {
                return NotFound("Posições dos veiculos não encontrada");
            }

            var posicaoVeiculoDto = _mapper.Map<IEnumerable<PosicaoVeiculoResponseDTO>>(posicaoVeiculo);

            return Ok(posicaoVeiculoDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterPosicaoVeiculo")]
        public async Task<ActionResult<PosicaoVeiculoResponseDTO>> GetParada(int id)
        {
            var posicao = await _unitOfWork.PosicaoVeiculoRepository.GetAsync(pa => pa.PosicaoVeiculoId == id);

            if (posicao is null)
            {
                return NotFound("Parada não encontrada");
            }

            var posicaoVeiculoDto = _mapper.Map<PosicaoVeiculoResponseDTO>(posicao);

            return Ok(posicaoVeiculoDto);
        }
    }
}
