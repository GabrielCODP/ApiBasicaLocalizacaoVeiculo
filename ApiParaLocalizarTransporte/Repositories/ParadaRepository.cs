using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;

namespace ApiParaLocalizarTransporte.Repositories
{
    public class ParadaRepository : Repository<Parada>, IParadaRepository
    {
        public ParadaRepository(AppDbContext context) : base(context)
        {
        }
        public Task<Parada> GetRetornaLinhasDeUmaDeterminadaParada(int id)
        {
            throw new NotImplementedException();
        }
    }
}
