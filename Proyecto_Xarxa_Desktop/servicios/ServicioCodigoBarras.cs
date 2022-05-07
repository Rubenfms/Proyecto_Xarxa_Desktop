using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    class ServicioCodigoBarras
    {
        private string path;
        private string date;

        public ServicioCodigoBarras()
        {
            path = Properties.Settings.Default.CarpetaXarxa;
            date = DateTime.Now.ToString("dd-MM-yyyy");
        }

        public void GenerarCB(string numero)
        {
            BarcodeWriter.CreateBarcode(numero, BarcodeWriterEncoding.EAN8).AddAnnotationTextBelowBarcode(numero).SaveAsPng(path + "/" + date + "_" + numero + ".png" );   
        }

        public void GenerarCB(int numero)
        {
            GenerarCB(numero.ToString());
        }
    }
}
