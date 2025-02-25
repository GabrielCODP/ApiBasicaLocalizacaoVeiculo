using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.DTOS.PosicaoVeiculoDTOs
{
    public class PosicaoVeiculoUpdateRequestDTO
    {
        [Required(ErrorMessage = "Id é obrigátorio")]
        public int PosicaoVeiculoId { get; set; }

        [Required(ErrorMessage = "O valor da latitude é obrigatório")]
        [Column(TypeName = "decimal(10,7)")]
        [Range(-90.0000000, 90.0000000, ErrorMessage = "Não é um valor valido para latitude")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "O valor da longitude é obrigatório")]
        [Column(TypeName = "decimal(10,7)")]
        [Range(-180.0000000, 180.0000000, ErrorMessage = "Não é um valor valido para longitude")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Id do veiculo é obrigátorio")]
        public int VeiculoId { get; set; }
    }
}
