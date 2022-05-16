using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Servicio de obtención de datos tratados
    /// </summary>
    class ServicioDatos
    {
        private static ServicioAPI servicioApi = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        /// <summary>
        /// Hace una llamada a la api de alumnos y se queda con solo los que no tienen un lote asignado
        /// </summary>
        /// <returns>
        /// Devuelve una lista de los NIAs de alumnos que no tienen un lote asignado y por tanto están disponibles
        /// </returns>
        public static ObservableCollection<int> ObtenerNiasDisponibles()
        {
            try
            {
                ObservableCollection<Alumno> listaAlumnos = servicioApi.GetAlumnos();

                ObservableCollection<int> result = new ObservableCollection<int>();
                foreach (Alumno a in listaAlumnos)
                {
                    // Si el alumno actual no tiene lote asignado, añadimos el nia de ese alumno a la lista de Nias disponibles
                    if (a.IdLote <= 0)
                    {
                        result.Add(a.Nia);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                ServicioDialogos.ServicioMessageBox("Error obteniendo los nias disponibles", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
            }
        }
    }
}
