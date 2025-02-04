using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.Filters;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;
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
        private readonly IParadaRepository _repository;
        public ParadaController(IParadaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parada>>> GetParadas()
        {

            var paradas = await _repository.GetAllAsync();

            if (paradas == null)
            {
                return NotFound("Paradas não encontrada...");
            }

            return Ok(paradas);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterParada")]
        public async Task<ActionResult<Parada>> GetParada(int id)
        {
            var parada = await _repository.GetAsync(pa => pa.ParadaId == id);

            if (parada is null)
            {
                return NotFound("Parada não encontrada");
            }

            return Ok(parada);
        }

        [HttpPost]
        public async Task<ActionResult<Parada>> PostParada(Parada parada)
        {
            if (parada is null)
            {
                return BadRequest();
            }

            var paradaCriada = _repository.Create(parada);
            await _repository.CommitAsync();

            return new CreatedAtRouteResult("ObterParada", new { id = paradaCriada.ParadaId }, paradaCriada);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<Parada>> PutParada(int id, Parada parada)
        {
            if (id != parada.ParadaId)
            {
                return BadRequest();
            }

            var paradaAtualizada = _repository.Update(parada);
            await _repository.CommitAsync();

            return Ok(parada);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<Parada>> DeleteParada(int id)
        {

            var parada = await _repository.GetAsync(pa => pa.ParadaId == id);

            if (parada is null)
            {
                return BadRequest();
            }

            var paradaDeletada = _repository.Delete(parada);

            await _repository.CommitAsync();

            return Ok(parada);

        }
    }
}
