using ApiParaLocalizarTransporte.DTOS.ParadaDTOs;

namespace ApiParaLocalizarTransporte.DTOS.LinhaDTOs
{
    public class LinhaEParadaResponseDTO
    {
        public int LinhaId { get; set; }
        public string? Name { get; set; }
        public ICollection<ParadaResponseDTO>? Paradas { get; set; }
    }
}
