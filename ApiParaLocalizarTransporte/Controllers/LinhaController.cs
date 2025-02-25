using ApiParaLocalizarTransporte.DTOS.LinhaDTOs;
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
    public class LinhaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LinhaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinhaResponseDTO>>> GetLinhas()
        {
            var linhas = await _unitOfWork.LinhaRepository.GetAllAsync();

            if (linhas is null)
            {
                return NotFound("Linhas não encontradas....");
            }

            var linhasResponseDTO = _mapper.Map<IEnumerable<LinhaResponseDTO>>(linhas);

            return Ok(linhasResponseDTO);
        }

        [HttpGet("com-paradas", Name = "ObterLinhasComParadas")]
        public async Task<ActionResult<IEnumerable<LinhaEParadaResponseDTO>>> GetLinhasComParadas()
        {
            var linhas = await _unitOfWork.LinhaRepository.GetLinhasEParadas();

            if (linhas is null)
            {
                return NotFound("Linhas não encontradas....");
            }

            var linhasResponseDTO = _mapper.Map<IEnumerable<LinhaEParadaResponseDTO>>(linhas);

            return Ok(linhasResponseDTO);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterLinha")]
        public async Task<ActionResult<LinhaResponseDTO>> GetLinha(int id)
        {
            var linha = await _unitOfWork.LinhaRepository.GetAsync(l => l.LinhaId == id);

            if (linha is null)
            {
                return NotFound("Linha não encontrada....");
            }

            var linhaResponseDTO = _mapper.Map<LinhaResponseDTO>(linha);

            return linhaResponseDTO;
        }

        [HttpPost]
        public async Task<ActionResult<LinhaResponseDTO>> PostLinha(LinhaCreateDTO linhaCreate)
        {
            if (linhaCreate is null)
            {
                return BadRequest();
            }

            var linha = _mapper.Map<Linha>(linhaCreate);

            var linhaCriada = _unitOfWork.LinhaRepository.Create(linha);
            await _unitOfWork.CommitAsync();

            var linhaCriadaDTO = _mapper.Map<LinhaResponseDTO>(linhaCriada);

            return new CreatedAtRouteResult("ObterLinha", new { id = linhaCriadaDTO.LinhaId }, linhaCriadaDTO);
        }

        [HttpPost("{idLinha:int:min(1)}/AdicionarParadaNaLinha/{idParada:int:min(1)}")]
        public async Task<ActionResult<LinhaEParadaResponseDTO>> PutLinha(int idLinha, int idParada)
        {
            var linha = await _unitOfWork.LinhaRepository.GetAsync(l => l.LinhaId == idLinha);
            var parada = await _unitOfWork.ParadaRepository.GetAsync(l => l.ParadaId == idParada);

            if (linha is null)
            {
                return BadRequest("Linha não foi encontrada ou não existe.");
            }
            if (parada is null)
            {
                return BadRequest("Parada não foi encontrada ou não existe.");
            }

            var paradaJaExisteNaLinha = await _unitOfWork.LinhaRepository.GetExisteParadaNaLinha(idLinha, idParada);

            if (paradaJaExisteNaLinha)
            {
                return BadRequest("Parada já existe na linha.");
            }

            var paradaELinhaAtualizado = _unitOfWork.LinhaRepository.InserirParadaNaLinha(linha, parada);

            await _unitOfWork.CommitAsync();

            var linhaAtualizadaDTO = _mapper.Map<LinhaEParadaResponseDTO>(paradaELinhaAtualizado);

            return Ok(linhaAtualizadaDTO);

        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<LinhaResponseDTO>> PutLinha(int id, LinhaUpdateRequestDTO linhaUpdate)
        {
            if (id != linhaUpdate.LinhaId)
            {
                return BadRequest();
            }

            var buscarlinha = await _unitOfWork.LinhaRepository.GetAsync(l => l.LinhaId == id);

            if (buscarlinha is null)
            {
                return NotFound("Linha não encontrada....");
            }

            var linha = _mapper.Map<Linha>(linhaUpdate);

            var linhaAtualizada = _unitOfWork.LinhaRepository.Update(linha);
            await _unitOfWork.CommitAsync();

            var linhaAtualizadaDTO = _mapper.Map<LinhaResponseDTO>(linhaAtualizada);


            return Ok(linhaAtualizadaDTO);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<LinhaResponseDTO>> DeleteLinha(int id)
        {
            var linha = await _unitOfWork.LinhaRepository.GetAsync(li => li.LinhaId == id);

            if (linha is null)
            {
                return NotFound("Linha não encontrada....");
            }

            var linhaDeletada = _unitOfWork.LinhaRepository.Delete(linha);
            await _unitOfWork.CommitAsync();

            var linhaDeletadaDTO = _mapper.Map<LinhaResponseDTO>(linhaDeletada);

            return Ok(linhaDeletadaDTO);
        }
    }
}
