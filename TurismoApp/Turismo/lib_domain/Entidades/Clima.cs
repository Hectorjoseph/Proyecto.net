using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Clima
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La temperatura es obligatoria")]
        public double Temperatura { get; set; }

        [Required(ErrorMessage = "La humedad es obligatoria")]
        public double Humedad { get; set; }

        [Required(ErrorMessage = "El estado del clima es obligatorio")]
        [MaxLength(50)]
        public required string Estado { get; set; }

        [ForeignKey("Lugar")]
        public int LugarId { get; set; }

        public required Lugar Lugar { get; set; }
    }
}