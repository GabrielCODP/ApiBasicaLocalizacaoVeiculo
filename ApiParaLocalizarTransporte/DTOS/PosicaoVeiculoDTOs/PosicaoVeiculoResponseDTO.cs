using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.DTOS.PosicaoVeiculoDTOs
{
    public class PosicaoVeiculoResponseDTO
    {
        public int PosicaoVeiculoId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int VeiculoId { get; set; }
    }
}
