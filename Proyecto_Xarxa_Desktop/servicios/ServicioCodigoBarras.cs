using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Clase Servicio Código de barras de los lotes
    /// </summary>
    class ServicioCodigoBarras
    {
        /// <summary>
        /// Path de la carpeta donde se almacenará el código
        /// </summary>
        private string path;
        /// <summary>
        /// La fecha actual
        /// </summary>
        private string date;

        public ServicioCodigoBarras()
        {
            path = Properties.Settings.Default.CarpetaXarxa;
            date = DateTime.Now.ToString("dd-MM-yyyy");
        }

        /// <summary>
        /// Generars the cb.
        /// </summary>
        /// <param name="numero">The numero.</param>
        public void GenerarCB(string numero)
        {
            BarcodeWriter.CreateBarcode(numero, BarcodeWriterEncoding.EAN8).AddAnnotationTextBelowBarcode(numero).SaveAsPng(path + "/" + date + "_" + numero + ".png" );   
        }

        /// <summary>
        /// Generars the cb.
        /// </summary>
        /// <param name="numero">The numero.</param>
        public void GenerarCB(int numero)
        {
            GenerarCB(numero.ToString());
        }
    }
}
