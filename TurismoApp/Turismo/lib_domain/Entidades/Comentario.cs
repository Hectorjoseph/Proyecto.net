using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(500)]
        public required string Texto { get; set; }

        public double? Calificacion { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [ForeignKey("Lugar")]
        public int LugarId { get; set; }

        public Lugar? Lugar { get; set; }
    }
}
