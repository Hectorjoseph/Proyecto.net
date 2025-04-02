using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Lugar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del lugar es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de lugar es obligatorio")]
        [MaxLength(50, ErrorMessage = "El tipo no puede exceder 50 caracteres")]
        public required string Tipo { get; set; }

        [Required(ErrorMessage = "La latitud es obligatoria")]
        [Range(-90.0, 90.0, ErrorMessage = "Latitud inválida")]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "La longitud es obligatoria")]
        [Range(-180.0, 180.0, ErrorMessage = "Longitud inválida")]
        public double Longitud { get; set; }

        [Range(0.0, 5.0, ErrorMessage = "La calificación debe estar entre 0 y 5")]
        public double? Calificacion { get; set; }

        // Relaciones
        public ICollection<Clima> Climas { get; set; } = new List<Clima>();
        public ICollection<PuntoRuta> PuntosRuta { get; set; } = new List<PuntoRuta>();
        public ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}