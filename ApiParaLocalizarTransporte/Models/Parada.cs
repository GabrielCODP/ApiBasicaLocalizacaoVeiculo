using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiParaLocalizarTransporte.Models
{
    public class Parada
    {

        [Key]
        public int ParadaId { get; set; }

        [StringLength(60, MinimumLength = 4, ErrorMessage = "O nome deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? Name { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public double Latitude { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public double Longitude { get; set; }

        public ICollection<Linha>? Linhas { get; set; }

        public Parada()
        {
            Linhas = new Collection<Linha>();
        }
    }
}
