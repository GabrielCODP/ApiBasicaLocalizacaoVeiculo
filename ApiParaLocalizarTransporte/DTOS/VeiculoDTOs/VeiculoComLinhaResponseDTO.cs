using ApiParaLocalizarTransporte.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.DTOS.VeiculoDTOs
{
    public class VeiculoComLinhaResponseDTO
    {
        public int VeiculoId { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public int LinhaId { get; set; }
    }
}
