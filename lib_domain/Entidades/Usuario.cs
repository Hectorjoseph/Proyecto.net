using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [MaxLength(150, ErrorMessage = "El email no puede exceder 150 caracteres")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [MaxLength(200)] // Para almacenar hash (no texto plano)
        public required string Contraseña { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Relaciones con otras entidades
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();
        public ICollection<HistorialBusqueda> HistorialBusquedas { get; set; } = new List<HistorialBusqueda>();
        public ICollection<Ruta> Rutas { get; set; } = new List<Ruta>();
    }
}