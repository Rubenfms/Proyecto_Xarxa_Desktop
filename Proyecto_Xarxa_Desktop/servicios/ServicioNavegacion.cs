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
        // Devuelve un nuevo UserControl de Libros
        internal static UserControl AbrirVistaLibros() => new LibrosUserControl();
        // Abre una nueva instancia de la ventana de login
        internal static void AbrirVistaLogIn() => new LogIn().Show();
        // Abre un dialogo generar lote
        internal static void AbrirVistaGenerarLote() => new GenerarLote().ShowDialog();        
        // Abre un dialogo editar lote
        internal static void AbrirVistaEditarLote() => new EditarLote().ShowDialog();          
        // Abre un dialogo asignar lote
        internal static void AbrirVistaAsignarLote() => new AsignarLoteDialog().ShowDialog();        
        // Abre un dialogo ver lote del alumno
        internal static void AbrirVistaVerLoteAlumno() => new VerLoteAlumno().ShowDialog();       
        // Abre un dialogo ver incidencias del alumno
        internal static void AbrirVistaVerIncidenciasAlumno() => new VerIncidenciasAlumno().ShowDialog();
        // Abre un dialogo dar de alta
        internal static void AbrirVistaDarDeAlta() => new DarDeAltaDialog().ShowDialog();
        // Abre diálogo opciones superusuario
        internal static void AbrirVistaOpcionesSU() => new OpcionesSuperUsuario().ShowDialog();
        // Abre diálogo nuevo usuario
        internal static void AbrirVistaNuevoUsuario() => new NuevoUsuarioDialog().ShowDialog();
    }
}
