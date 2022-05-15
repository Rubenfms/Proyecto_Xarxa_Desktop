using Proyecto_Xarxa_Desktop.informes;
using Proyecto_Xarxa_Desktop.vistas;
using Proyecto_Xarxa_Desktop.vistasInformes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Servicio de navegación entre ventanas/diálogos
    /// </summary>
    internal class ServicioNavegacion
    {
        public ServicioNavegacion()
        { }

        /// <summary>
        /// Devuelve un nuevo UserControl de Lotes.
        /// </summary>
        /// <returns>Devuelve un nuevo UserControl de Lotes.</returns>
        internal static UserControl AbrirVistaLotes() => new LotesUserControl();

        /// <summary>
        /// Devuelve un nuevo UserControl de Alumnos.
        /// </summary>
        /// <returns>Devuelve un nuevo UserControl de Alumnos.</returns>
        internal static UserControl AbrirVistaAlumnos() => new AlumnosUserControl();

        /// <summary>
        /// Devuelve un nuevo UserControl de Libros.
        /// </summary>
        /// <returns>Devuelve un nuevo UserControl de Libros.</returns>
        internal static UserControl AbrirVistaLibros() => new LibrosUserControl();

        /// <summary>
        /// Abre una nueva instancia de la ventana de login
        /// </summary>
        internal static void AbrirVistaLogIn() => new LogIn().Show();

        /// <summary>
        /// Abre un dialogo generar lote.
        /// </summary>
        internal static void AbrirVistaGenerarLote() => new GenerarLote().ShowDialog();

        /// <summary>
        /// Abre un dialogo editar lote.
        /// </summary>
        internal static void AbrirVistaEditarLote() => new EditarLote().ShowDialog();


        /// <summary>
        /// Abre un dialogo asignar lote.
        /// </summary>
        internal static void AbrirVistaAsignarLote() => new AsignarLoteDialog().ShowDialog();

        /// <summary>
        /// Abre un dialogo ver lote del alumno.
        /// </summary>
        internal static void AbrirVistaVerLoteAlumno() => new VerLoteAlumno().ShowDialog();


        /// <summary>
        /// Abre un dialogo ver incidencias del alumno.
        /// </summary>
        internal static void AbrirVistaVerIncidenciasAlumno() => new VerIncidenciasAlumno().ShowDialog();

        /// <summary>
        /// Abre un dialogo dar de alta.
        /// </summary>
        internal static void AbrirVistaDarDeAlta() => new DarDeAltaDialog().ShowDialog();

        /// <summary>
        /// Abre diálogo opciones superusuario.
        /// </summary>
        internal static void AbrirVistaOpcionesSU() => new OpcionesSuperUsuario().ShowDialog();

        /// <summary>
        /// Abre diálogo nuevo usuario.
        /// </summary>
        internal static void AbrirVistaNuevoUsuario() => new NuevoUsuarioDialog().ShowDialog();
        internal static UserControl AbrirVistaInformes() => new InformesUserControl();

        // INFORMES

        internal static void AbrirInformeXarxaCompleto() => new InformeXarxaCompleto().ShowDialog();
        internal static void AbrirInformeConcesion() => new InformeConcesion().ShowDialog();
        internal static void AbrirInformeXarxaGrupos() => new InformeXarxaGrupos().ShowDialog();
        internal static void AbrirInformeRecogida() => new InformeRecogida().ShowDialog();
        internal static void AbrirInformeLotes() => new InformeLotes().ShowDialog();
        internal static void AbrirInformeEtiquetas() => new InformeEtiquetas().ShowDialog();
        internal static void AbrirInformeEtiquetasBolsa() => new InformeEtiquetasBolsa().ShowDialog();

    }
}
