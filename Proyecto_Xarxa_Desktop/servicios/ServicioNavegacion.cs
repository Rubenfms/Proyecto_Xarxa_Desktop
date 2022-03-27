using Proyecto_Xarxa_Desktop.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proyecto_Xarxa_Desktop.servicios
{
    internal class ServicioNavegacion
    {
        public ServicioNavegacion()
        { }

        // Devuelve un nuevo UserControl de Lotes
        internal static UserControl AbrirVistaLotes() => new LotesUserControl();
    }
}
