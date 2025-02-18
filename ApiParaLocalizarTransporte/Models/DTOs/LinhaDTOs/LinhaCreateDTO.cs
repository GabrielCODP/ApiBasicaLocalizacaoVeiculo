using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.Models.DTOs.LinhaDTOs
{
    public class LinhaCreateDTO
    {
        [Required(ErrorMessage = "O nome da linha é obrigatório")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "O nome deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? Name { get; set; }
    }
}
