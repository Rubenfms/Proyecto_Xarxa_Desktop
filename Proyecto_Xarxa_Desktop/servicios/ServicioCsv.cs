using Proyecto_Xarxa_Desktop.enumerados;
using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Servicio de la carga de datos mediante CSV
    /// </summary>
    class ServicioCsv
    {
        private static ObservableCollection<Alumno> listaAlumnosGeneral = new ObservableCollection<Alumno>();

        public static ObservableCollection<Alumno> ListaAlumnosGeneral
        {
            get { return listaAlumnosGeneral; }
            set { listaAlumnosGeneral = value; }
        }

        private static ObservableCollection<Alumno> listaAlumnosDefinitiva = new ObservableCollection<Alumno>();

        /// <summary>
        /// Lee el CSV de la lista de alumnos general y lo guarda en la lista de alumnos general.
        /// </summary>
        public static void LeeCsvAlumnosGeneral()
        {
            try
            {
                StreamReader archivo = new StreamReader(Properties.Settings.Default.UbicacionCsvListaAlumnosGeneral);
                archivo.ReadLine(); // Leer la primera línea para descartarla porque es el encabezado
                string linea = "";
                char separador = ',';

                while ((linea = archivo.ReadLine()) != null)
                {
                    string[] fila = linea.Replace("\"", "").Split(separador); // Replace para eliminar todas las comillas dobles 

                    //EstadoMatricula estadoMatricula = EstadoMatriculaStringToEnum(fila[7]); // Estado Matricula del alumno
                    string date = fila[4];
                    DateTime fechaNacimiento = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture); // Fecha Nacimiento del alumno

                    // Añadimos solo los usuarios que puedan pertenecer a la xarxa (1,2,3 y 4 de la eso y 1FPB 2FPB)
                    string filtro = fila[11].ToString();
                    if(filtro.Equals("1ESO") || filtro.Equals("2ESO") || filtro.Equals("3ESO") || filtro.Equals("4ESO") || filtro.Equals("1FPB") || filtro.Equals("2FPB"))
                    {
                        ListaAlumnosGeneral.Add(new Alumno(int.Parse(fila[0]), fila[1], fila[2], fila[3], fila[7], fila[11], fila[12], "", false));
                    }
                }
            }
            catch (FormatException)
            {
                ServicioDialogos.ServicioMessageBox("Error en el formato de fecha de nacimiento", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("Una entrada no tiene fecha de nacimiento (null)", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

            }
            catch (IOException)
            {
                ServicioDialogos.ServicioMessageBox("Error de entrada/salida en el fichero de datos", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            catch (Exception)
            {
                ServicioDialogos.ServicioMessageBox("Ha ocurrido un error inesperado", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

            }
        }

        /// <summary>
        /// Lee fichero con una lista de alumnos pertenecientes a la xarxa y comprueba si están en la lista de alumnos 
        /// </summary>
        public static void LeeCsvAlumnosXarxa()
        {
            try
            {
                StreamReader archivo = new StreamReader(Properties.Settings.Default.UbicacionCsvListaAlumnosXarxa);
                archivo.ReadLine(); // Leer la primera línea para descartarla porque es el encabezado
                string linea = "";
                char separador = ',';

                while ((linea = archivo.ReadLine()) != null)
                {
                    string[] fila = linea.Replace("\"", "").Split(separador); // Replace para eliminar todas las comillas dobles 

                    // Comprobamos si el nia del alumno del fichero coincide con alguno de la lista
                    string nia = fila[4];
                    foreach(Alumno a in ListaAlumnosGeneral)
                    {
                        // Si coincide marcamos que pertenece a la xarxa
                        if(a.Nia == int.Parse(nia))
                        {
                            a.PerteneceXarxa = true;
                        }
                    }
                }
            }
            catch (IOException)
            {
                ServicioDialogos.ServicioMessageBox("Error de entrada/salida en el fichero de datos", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            catch (Exception)
            {
                ServicioDialogos.ServicioMessageBox("Ha ocurrido un error inesperado", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Método que quita los alumnos no pertenecientes a la Xarxa
        /// </summary>
        public static void QuitarAlumnosNoXarxa()
        {
            foreach(Alumno a in ListaAlumnosGeneral)
            {
                if(a.PerteneceXarxa)
                {
                    listaAlumnosDefinitiva.Add(a);
                }
            }
        }

        /// <summary>
        /// Devuelve lista de alumnos (contrastando si pertenecen a la xarxa o no)   
        /// </summary>
        /// <returns>
        /// Devuelve una lista de alumnos
        /// </returns>
        public static ObservableCollection<Alumno> GetListaAlumnosFromCSV()
        {
            LeeCsvAlumnosGeneral();
            LeeCsvAlumnosXarxa();
            //QuitarAlumnosNoXarxa();
            //return listaAlumnosDefinitiva;
            return ListaAlumnosGeneral;
        }
        
        /// <summary>
        /// Recibe string y devuelve Enum EstadoMatricula
        /// </summary>
        /// <param name="estadoMatricula">The estado matricula.</param>
        /// <returns>
        /// Devuelve un EstadoMatricula
        /// </returns>
        public static EstadoMatricula EstadoMatriculaStringToEnum(string estadoMatricula)
            => estadoMatricula.Equals("Matriculado") ? EstadoMatricula.ALTA : EstadoMatricula.BAJA;

    }
}