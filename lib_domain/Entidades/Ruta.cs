using System;
using System.Collections.Generic; // Para ICollection
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Para ForeignKey

namespace lib_dominio.Entidades
{
    public class Ruta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El origen es obligatorio")]
        [MaxLength(100)]
        public required string Origen { get; set; }

        [Required(ErrorMessage = "El destino es obligatorio")]
        [MaxLength(100)]
        public required string Destino { get; set; }

        [Required(ErrorMessage = "La distancia es obligatoria")]
        public double Distancia { get; set; }

        [Required(ErrorMessage = "El tiempo estimado es obligatorio")]
        public double TiempoEstimado { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        // Relación con PuntoRuta
        public ICollection<PuntoRuta> PuntosRuta { get; set; } = new List<PuntoRuta>();
    }
}
