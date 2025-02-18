using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiParaLocalizarTransporte.Models
{
    public class Linha
    {
        [Key]
        public int LinhaId { get; set; }
        [Required(ErrorMessage = "O nome da linha é obrigatório")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "O nome deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? Name { get; set; }
        public ICollection<Parada>? Paradas { get; set; }

        public Linha()
        {
            Paradas = new Collection<Parada>();
        }
    }
}
