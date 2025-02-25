using ApiParaLocalizarTransporte.DTOS.ParadaDTOs;
using ApiParaLocalizarTransporte.DTOS.VeiculoDTOs;
using ApiParaLocalizarTransporte.Filters;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiParaLocalizarTransporte.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public class VeiculoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VeiculoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoResponseDTO>>> GetVeiculos()
        {
            var veiculos = await _unitOfWork.VeiculoRepository.GetAllAsync();

            if (veiculos is null)
            {
                return NotFound("Veiculos não encontrado...");
            }

            var veiculoDto = _mapper.Map<IEnumerable<VeiculoResponseDTO>>(veiculos);

            return Ok(veiculoDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterVeiculo")]
        public async Task<ActionResult<VeiculoResponseDTO>> GetVeiculo(int id)
        {
            var veiculo = await _unitOfWork.VeiculoRepository.GetAsync(v => v.VeiculoId == id);

            if (veiculo is null)
            {
                return NotFound("Veiculos não encontrado...");
            }

            var veiculoDTO = _mapper.Map<VeiculoResponseDTO>(veiculo);

            return Ok(veiculoDTO);
        }

        [HttpGet("{id:int:min(1)}/GetVeiculoComLinha")]
        public async Task<ActionResult<VeiculoComLinhaResponseDTO>> GetVeiculoComLinha(int id)
        {
            var veiculo = await _unitOfWork.VeiculoRepository.GetVeiculoComLinha(id);

            if (veiculo is null)
            {
                return NotFound("Veiculos não encontrado...");
            }

            var veiculoDTO = _mapper.Map<VeiculoComLinhaResponseDTO>(veiculo);

            return Ok(veiculoDTO);
        }




        [HttpPost]
        public async Task<ActionResult<VeiculoResponseDTO>> PostVeiculo(VeiculoCreateDTO veiculoCreateDTO)
        {
            if (veiculoCreateDTO is null)
            {
                return BadRequest();
            }

            var veiculo = _mapper.Map<Veiculo>(veiculoCreateDTO);

            var createVeiculo = _unitOfWork.VeiculoRepository.Create(veiculo);
            await _unitOfWork.CommitAsync();

            var veiculoResponse = _mapper.Map<VeiculoResponseDTO>(createVeiculo);

            return new CreatedAtRouteResult("ObterVeiculo", new { id = veiculoResponse.VeiculoId }, veiculoResponse);
        }

        [HttpPost("{idVeiculo:int:min(1)}/AdicionarLinhaNoVeiculo/{idLinha:int:min(1)}")]
        public async Task<ActionResult<VeiculoComLinhaResponseDTO>> PostInserirLinhaNoVeiculo(int idVeiculo, int idLinha)
        {
            var veiculo = await _unitOfWork.VeiculoRepository.GetAsync(v => v.VeiculoId == idVeiculo);
            var linha = await _unitOfWork.LinhaRepository.GetAsync(l => l.LinhaId == idLinha);

            if (linha is null)
            {
                return BadRequest("Linha não foi encontrada ou não existe.");
            }
            if (veiculo is null)
            {
                return BadRequest("Veiculo não foi encontrado ou não existe.");
            }

            var veiculoLinhaAtualizada = _unitOfWork.VeiculoRepository.PostInserirLinhaIdNoVeiculo(veiculo, idLinha);

            await _unitOfWork.CommitAsync();

            var veiculoELinhaDTO = _mapper.Map<VeiculoComLinhaResponseDTO>(veiculoLinhaAtualizada);

            return Ok(veiculoELinhaDTO);
        }

        [HttpPut]
        public async Task<ActionResult<VeiculoResponseDTO>> PutVeiculo(int idVeiculo, VeiculoUpdateRequestDTO veiculoUpdateDTO)
        {
            if (idVeiculo != veiculoUpdateDTO.VeiculoId)
            {
                return BadRequest();
            }

            var buscarVeiculo = await _unitOfWork.VeiculoRepository.GetAsync(v => v.VeiculoId == idVeiculo);

            if (buscarVeiculo is null)
            {
                return NotFound("Veiculos não encontrado...");
            }

            var veiculo = _mapper.Map<Veiculo>(veiculoUpdateDTO);

            var veiculoAtualizado = _unitOfWork.VeiculoRepository.Update(veiculo);
            await _unitOfWork.CommitAsync();

            var retornaVeiculoAtualizado = _mapper.Map<VeiculoResponseDTO>(veiculoAtualizado);

            return Ok(retornaVeiculoAtualizado);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<Veiculo>> DeleteVeiculo(int id)
        {

            var veiculo = await _unitOfWork.VeiculoRepository.GetAsync(v => v.VeiculoId == id);

            if (veiculo is null)
            {
                return BadRequest();
            }

            var veiculoDeletado = _unitOfWork.VeiculoRepository.Delete(veiculo);

            await _unitOfWork.CommitAsync();

            var retornaVeiculoDeletado = _mapper.Map<VeiculoResponseDTO>(veiculoDeletado);

            return Ok(retornaVeiculoDeletado);

        }
    }
}
