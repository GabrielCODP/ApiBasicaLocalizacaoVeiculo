using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.DTOS.VeiculoDTOs;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiParaLocalizarTransporte.Repositories
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Veiculo> GetVeiculoComLinha(int idVeiculo)
        {
            return await _context.Set<Veiculo>().AsNoTracking().FirstOrDefaultAsync(v => v.VeiculoId == idVeiculo);
        }

        public Veiculo PostInserirLinhaIdNoVeiculo(Veiculo veiculo, int idLinha)
        {
            veiculo.LinhaId = idLinha;
            Update(veiculo);

            return veiculo;
        }
    }
}
