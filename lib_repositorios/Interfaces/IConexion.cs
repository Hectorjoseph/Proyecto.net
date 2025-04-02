using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Usuario>? Usuarios { get; set; }
        DbSet<Lugar>? Lugares { get; set; }
        DbSet<Clima>? Climas { get; set; }
        DbSet<Ruta>? Rutas { get; set; }
        DbSet<PuntoRuta>? PuntosRuta { get; set; }
        DbSet<Comentario>? Comentarios { get; set; }
        DbSet<Favorito>? Favoritos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
