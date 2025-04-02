using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ut_presentacion.Repositorios
{
    public class UsuarioRepositorioPruebas
    {
        private readonly Conexion iConexion; // Se usa Conexion directamente en lugar de IConexion
        private List<Usuario>? lista;
        private Usuario? entidad;

        public UsuarioRepositorioPruebas()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [Fact]
        public void Ejecutar()
        {
            Assert.True(Guardar());
            Assert.True(Modificar());
            Assert.True(Listar());
            Assert.True(Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Usuarios!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = new Usuario
            {
                Nombre = "Juan Pérez",
                Email = "juanperez@example.com",
                Contraseña = "Segura123"
            };

            this.iConexion!.Usuarios!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Contraseña = "NuevaClave456";

            var entry = this.iConexion!.Entry<Usuario>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Usuarios!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
