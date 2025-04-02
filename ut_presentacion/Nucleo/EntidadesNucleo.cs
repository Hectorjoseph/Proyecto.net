using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ut_presentacion.Nucleo
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        // Propiedad requerida: Contraseña
        [Required]
        public string Contraseña { get; set; } = string.Empty;
    }

    public class Lugar
    {
        [Key]
        public int Id { get; set; }

        // Propiedad requerida: Nombre
        [Required]
        public string Nombre { get; set; } = string.Empty;

        // Se agrega la propiedad Dirección
        [Required]
        public string Direccion { get; set; } = string.Empty;

        // Propiedad requerida: Tipo
        [Required]
        public string Tipo { get; set; } = string.Empty;
    }

    public class Clima
    {
        [Key]
        public int Id { get; set; }

        // Propiedad requerida: Estado
        [Required]
        public string Estado { get; set; } = string.Empty;

        // Propiedad requerida: Lugar asociado
        [Required]
        public Lugar Lugar { get; set; } = new Lugar();

        // Se agrega la propiedad Descripcion
        [Required]
        public string Descripcion { get; set; } = string.Empty;

        // Temperatura en double para evitar conversiones implícitas con decimal
        public double Temperatura { get; set; }
    }

    public class Ruta
    {
        [Key]
        public int Id { get; set; }

        // Propiedad requerida: Origen
        [Required]
        public string Origen { get; set; } = string.Empty;

        // Propiedad requerida: Nombre
        [Required]
        public string Nombre { get; set; } = string.Empty;

        // Distancia como double para evitar conversiones
        public double Distancia { get; set; }
    }

    public class PuntoRuta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Orden { get; set; }

        [ForeignKey("Lugar")]
        public int LugarId { get; set; }
        public Lugar Lugar { get; set; } = new Lugar();

        [ForeignKey("Ruta")]
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; } = new Ruta();
    }

    public class Favorito
    {
        [Key]
        public int Id { get; set; }

        // Asumiendo relación con Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();

        // Asumiendo relación con Lugar
        [ForeignKey("Lugar")]
        public int LugarId { get; set; }
        public Lugar Lugar { get; set; } = new Lugar();

        public DateTime FechaFavorito { get; set; } = DateTime.Now;
    }

    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Contenido { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Asumiendo relación con Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();

        // Asumiendo relación con Lugar
        [ForeignKey("Lugar")]
        public int LugarId { get; set; }
        public Lugar Lugar { get; set; } = new Lugar();
    }

    public class HistorialBusqueda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Termino { get; set; } = string.Empty;

        public DateTime FechaBusqueda { get; set; } = DateTime.Now;

        // Asumiendo relación con Usuario
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
    }
}

