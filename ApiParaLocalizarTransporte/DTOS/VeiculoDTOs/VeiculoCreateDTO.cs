using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.DTOS.VeiculoDTOs
{
    public class VeiculoCreateDTO
    {
        [Required(ErrorMessage = "O nome da veiculo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O nome do veículo deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O nome da modelo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O nome do modelo deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? Model { get; set; }
    }
}
