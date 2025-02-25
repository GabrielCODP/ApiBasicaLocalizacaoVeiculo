using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.DTOS.VeiculoDTOs
{
    public class VeiculoResponseDTO
    {
        public int VeiculoId { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
    }
}
