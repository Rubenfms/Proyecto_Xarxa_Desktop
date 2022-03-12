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
    class ServicioCsv
    {

        //TODO: Hacer servicio csv alumnosxarxa y que compare con la lista de alumnos 
        public static void LeeCsv()
        {
            ObservableCollection<Alumno> listaAlumnos = new ObservableCollection<Alumno>();
            StreamReader archivo = new StreamReader(Properties.Settings.Default.UbicacionCsv);
            archivo.ReadLine(); // Leer la primera línea para descartarla porque es el encabezado
            String linea = "";
            Char separador = ',';
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Replace("\"", "").Split(separador);

                EstadoMatricula estadoMatricula = EstadoMatriculaStringToEnum(fila[7]); // Estado Matricula del alumno
                String date = fila[4];
                DateTime fechaNacimiento = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture); // Fecha Nacimiento del alumno

                listaAlumnos.Add(new Alumno(Int32.Parse(fila[0]), fila[1], fila[2], fila[3], fechaNacimiento, estadoMatricula, fila[11], fila[12], ""));
            }

        }

        // Recibe string y devuelve Enum EstadoMatricula
        public static EstadoMatricula EstadoMatriculaStringToEnum(string estadoMatricula) 
            => estadoMatricula.Equals("Matriculado") ? EstadoMatricula.ALTA : EstadoMatricula.BAJA;

    }
}