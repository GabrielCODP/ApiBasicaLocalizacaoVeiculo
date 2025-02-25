using ApiParaLocalizarTransporte.DTOS.VeiculoDTOs;
using ApiParaLocalizarTransporte.Models;

namespace ApiParaLocalizarTransporte.Repositories.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Veiculo PostInserirLinhaIdNoVeiculo(Veiculo veiculo, int idlinha);
        Task<Veiculo> GetVeiculoComLinha(int idVeiculo);
    }
}
