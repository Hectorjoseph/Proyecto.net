using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class HistorialBusqueda
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de búsqueda es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "La búsqueda realizada es obligatoria")]
        [MaxLength(200)]
        public required string BusquedaRealizada { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public required Usuario Usuario { get; set; }
    }
}
