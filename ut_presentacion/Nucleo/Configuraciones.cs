using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ut_presentacion.Nucleo
{
    public static class Configuraciones
    {
        // Diccionario para almacenar la configuración leída desde el archivo JSON
        private static readonly Dictionary<string, string> configuracion;

        // Constructor estático: se ejecuta una sola vez al cargar la clase
        static Configuraciones()
        {
            // Especifica la ruta del archivo de configuración (ajusta la ruta si es necesario)
            string rutaArchivo = "secrets.json";

            try
            {
                if (File.Exists(rutaArchivo))
                {
                    string contenido = File.ReadAllText(rutaArchivo);
                    configuracion = JsonConvert.DeserializeObject<Dictionary<string, string>>(contenido)
                                    ?? new Dictionary<string, string>();
                }
                else
                {
                    // Si no existe el archivo, inicializamos el diccionario vacío
                    configuracion = new Dictionary<string, string>();
                }
            }
            catch (Exception ex)
            {
                // En caso de error, se inicializa un diccionario vacío y se podría registrar el error
                Console.WriteLine("Error al cargar la configuración: " + ex.Message);
                configuracion = new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Obtiene el valor asociado a una clave en el archivo de configuración.
        /// </summary>
        /// <param name="clave">La clave a buscar en la configuración.</param>
        /// <returns>El valor asociado si existe; de lo contrario, una cadena vacía.</returns>
        public static string ObtenerValor(string clave)
        {
            return configuracion.ContainsKey(clave) ? configuracion[clave] : string.Empty;
        }
    }
}

