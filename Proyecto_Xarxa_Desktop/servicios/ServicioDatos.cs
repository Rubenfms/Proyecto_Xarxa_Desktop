using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    class ServicioDatos
    {
        private static ServicioAPI servicioApi = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        public static ObservableCollection<int> ObtenerNiasDisponibles()
        {
            try
            {
                ObservableCollection<Alumno> listaAlumnos = servicioApi.GetAlumnos();

                ObservableCollection<int> result = new ObservableCollection<int>();
                foreach (Alumno a in listaAlumnos)
                {
                    // Si el alumno actual no tiene lote asignado, añadimos el nia de ese alumno a la lista de Nias disponibles
                    if (a.IdLote == null || a.IdLote <= 0)
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
