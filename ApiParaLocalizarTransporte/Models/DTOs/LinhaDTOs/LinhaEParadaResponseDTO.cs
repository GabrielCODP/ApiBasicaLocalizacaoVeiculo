
using ApiParaLocalizarTransporte.Models.DTOs.ParadaDTOs;

namespace ApiParaLocalizarTransporte.Models.DTOs.LinhaDTOs
{
    public class LinhaEParadaResponseDTO
    {
        public int LinhaId { get; set; }
        public string? Name { get; set; }
        public ICollection<ParadaResponseDTO>? Paradas { get; set; }
    }
}
