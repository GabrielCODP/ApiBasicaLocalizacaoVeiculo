using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.Models;
using ApiParaLocalizarTransporte.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiParaLocalizarTransporte.Repositories
{
    public class LinhaRepository : Repository<Linha>, ILinhaRepository
    {
        public LinhaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> GetExisteParadaNaLinha(int linhaId, int paradaId)
        {
            var linhaEParada = await _context.Set<Linha>().AsNoTracking().
                Where(l => l.LinhaId == linhaId).Select(l => l.Paradas.Any(p => p.ParadaId == paradaId)).FirstOrDefaultAsync();
            return linhaEParada;
        }

        public async Task<IEnumerable<Linha>> GetLinhasEParadas()
        {
            return await _context.Set<Linha>().AsNoTracking().Include(p => p.Paradas).ToListAsync();
        }

        public Linha InserirParadaNaLinha(Linha linha, Parada parada)
        {
            linha.Paradas.Add(parada);

            Update(linha);

            return linha;
        }

    }
}
