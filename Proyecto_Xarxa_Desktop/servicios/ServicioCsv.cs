using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    class ServicioCsv
    {
        public static void LeeCsv()
        {
            StreamReader archivo = new StreamReader(Properties.Settings.Default.UbicacionCsv);
            archivo.ReadLine(); // Leer la primera línea para descartarla porque es el encabezado
            String linea = "";
            Char separador = ',';
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                Console.WriteLine(fila);
            }
        }
    }
}