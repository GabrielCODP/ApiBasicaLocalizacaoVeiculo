using ApiParaLocalizarTransporte.Models;

namespace ApiParaLocalizarTransporte.Repositories.Interfaces
{
    public interface ILinhaRepository : IRepository<Linha>
    {
        Task<bool> GetExisteParadaNaLinha(int linhaId, int paradaId);
        Task<IEnumerable<Linha>> GetLinhasEParadas();
        Linha InserirParadaNaLinha(Linha linha, Parada parada);
    }
}
