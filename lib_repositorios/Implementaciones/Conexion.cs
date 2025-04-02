using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using lib_dominio.Entidades;          
using lib_repositorios.Interfaces;     

namespace lib_repositorios.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        // DbSet para cada entidad del dominio
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Lugar>? Lugares { get; set; }
        public DbSet<Clima>? Climas { get; set; }
        public DbSet<Ruta>? Rutas { get; set; }
        public DbSet<PuntoRuta>? PuntosRuta { get; set; }
        public DbSet<Comentario>? Comentarios { get; set; }
        public DbSet<Favorito>? Favoritos { get; set; }

        // Configuración del contexto utilizando la cadena de conexión
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(StringConexion))
            {
                optionsBuilder.UseSqlServer(StringConexion);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        // Permite obtener la entrada de una entidad para gestionar su estado
        public new EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }

        // Guarda los cambios realizados en el contexto hacia la base de datos
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
