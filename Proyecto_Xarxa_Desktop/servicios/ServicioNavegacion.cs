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
        // Devuelve un nuevo UserControl de Alumnos
        internal static UserControl AbrirVistaAlumnos() => new AlumnosUserControl();
        // Abre una nueva instancia de la ventana de login
        internal static void AbrirVistaLogIn() => new LogIn().Show();
        // Abre un dialogo generar lote
        internal static void AbrirVistaGenerarLote() => new GenerarLote().ShowDialog();
        // Abre un dialogo dar de alta
        internal static void AbrirVistaDarDeAlta() => new DarDeAltaDialog().ShowDialog();


    }
}
