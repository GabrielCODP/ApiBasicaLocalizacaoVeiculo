using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.DTOS.ParadaDTOs;
using ApiParaLocalizarTransporte.Filters;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiParaLocalizarTransporte.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public class ParadaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParadaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParadaResponseDTO>>> GetParadas()
        {

            var paradas = await _unitOfWork.ParadaRepository.GetAllAsync();

            if (paradas == null)
            {
                return NotFound("Paradas não encontradas...");
            }

            var paradaDto = _mapper.Map<IEnumerable<ParadaResponseDTO>>(paradas);

            return Ok(paradaDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterParada")]
        public async Task<ActionResult<ParadaResponseDTO>> GetParada(int id)
        {
            var parada = await _unitOfWork.ParadaRepository.GetAsync(pa => pa.ParadaId == id);

            if (parada is null)
            {
                return NotFound("Parada não encontrada");
            }

            var paradaDto = _mapper.Map<ParadaResponseDTO>(parada);

            return Ok(paradaDto);
        }

        [HttpPost]
        public async Task<ActionResult<ParadaResponseDTO>> PostParada(ParadaCreateDTO paradaCreateDTO)
        {
            if (paradaCreateDTO is null)
            {
                return BadRequest();
            }

            var paradaCreate = _mapper.Map<Parada>(paradaCreateDTO);

            var paradaCriada = _unitOfWork.ParadaRepository.Create(paradaCreate);
            await _unitOfWork.CommitAsync();

            var retornaParadaCriada = _mapper.Map<ParadaResponseDTO>(paradaCriada);

            return new CreatedAtRouteResult("ObterParada", new { id = retornaParadaCriada.ParadaId }, retornaParadaCriada);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<ParadaResponseDTO>> PutParada(int id, ParadaUpdateRequestDTO paradaUpdate)
        {
            if (id != paradaUpdate.ParadaId)
            {
                return BadRequest();
            }

            var buscarParada = await _unitOfWork.ParadaRepository.GetAsync(pa => pa.ParadaId == id);

            if (buscarParada is null)
            {
                return NotFound("Parada não encontrada");
            }

            var parada = _mapper.Map<Parada>(paradaUpdate);

            var paradaAtualizada = _unitOfWork.ParadaRepository.Update(parada);
            await _unitOfWork.CommitAsync();

            var retornaParadaAtualizada = _mapper.Map<ParadaResponseDTO>(paradaAtualizada);

            return Ok(retornaParadaAtualizada);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<Parada>> DeleteParada(int id)
        {

            var parada = await _unitOfWork.ParadaRepository.GetAsync(pa => pa.ParadaId == id);

            if (parada is null)
            {
                return BadRequest();
            }

            var paradaDeletada = _unitOfWork.ParadaRepository.Delete(parada);

            await _unitOfWork.CommitAsync();

            var retornaParadaDeletada = _mapper.Map<ParadaResponseDTO>(paradaDeletada);

            return Ok(retornaParadaDeletada);

        }
    }
}
