using ApiParaLocalizarTransporte.Models;

namespace ApiParaLocalizarTransporte.Repositories.Interfaces
{
    public interface IParadaRepository : IRepository<Parada>
    {
        Task<Parada> GetRetornaLinhasDeUmaDeterminadaParada(int id);
    }
}
