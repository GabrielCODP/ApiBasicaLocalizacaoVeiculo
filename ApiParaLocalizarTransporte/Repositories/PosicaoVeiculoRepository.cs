using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;

namespace ApiParaLocalizarTransporte.Repositories
{
    public class PosicaoVeiculoRepository : Repository<PosicaoVeiculo>, IPosicaoVeiculoRepository
    {
        public PosicaoVeiculoRepository(AppDbContext context) : base(context) 
        { 
        }
    }
}
