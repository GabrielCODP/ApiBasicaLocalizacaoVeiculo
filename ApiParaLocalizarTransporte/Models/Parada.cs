﻿using ApiParaLocalizarTransporte.Validations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiParaLocalizarTransporte.Models
{
    public class Parada
    {

        [Key]
        public int ParadaId { get; set; }

        [Required(ErrorMessage = "O nome da parada é obrigatório")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "O nome deve ter no máximo {1} caracteres e no mínimo {2}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O valor da latitude é obrigatório")]
        [Column(TypeName = "decimal(10,7)")]
        [Range(-90.0000000, 90.0000000, ErrorMessage = "Não é um valor valido para latitude")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "O valor da longitude é obrigatório")]
        [Column(TypeName = "decimal(10,7)")]
        [Range(-180.0000000, 180.0000000, ErrorMessage = "Não é um valor valido para longitude")]
        public double Longitude { get; set; }
        public ICollection<Linha>? Linhas { get; set; }

        public Parada()
        {
            Linhas = new Collection<Linha>();
        }
    }
}
