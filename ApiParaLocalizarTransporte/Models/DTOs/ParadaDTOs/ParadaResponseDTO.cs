using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.Models.DTOs.ParadaDTOs
{
    public class ParadaResponseDTO
    {
        public int ParadaId { get; set; }
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
