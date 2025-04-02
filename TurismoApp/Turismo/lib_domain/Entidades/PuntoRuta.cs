using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class PuntoRuta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El orden del punto en la ruta es obligatorio")]
        public int Orden { get; set; }

        [ForeignKey("Lugar")]
        public int LugarId { get; set; }
        public Lugar? Lugar { get; set; }

        [ForeignKey("Ruta")]
        public int RutaId { get; set; }
        public Ruta? Ruta { get; set; }
    }
}