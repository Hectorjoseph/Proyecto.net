using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Favorito
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de agregado es obligatoria")]
        public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [ForeignKey("Lugar")]
        public int LugarId { get; set; }

        public Lugar? Lugar { get; set; }
    }
}
