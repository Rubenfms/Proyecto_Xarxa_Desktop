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
        /// Abre una nueva instancia del dialogo anyadir libro.
        /// </summary>
        internal static void AbrirVistaAnyadirLibro() => new AnyadirLibroDialog().ShowDialog();

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

        /// <summary>
        /// Abre la vista administrar usuarios.
        /// </summary>
        internal static void AbrirVistaAdministrarUsuarios() => new AdministrarUsuariosDialog().ShowDialog();

        /// <summary>
        /// Abre la vista cargar CSV.
        /// </summary>
        internal static void AbrirVistaCargarCSV() => new CargarCSVDialog().ShowDialog();
        /// <summary>
        /// Abre la vista informes.
        /// </summary>
        /// <returns></returns>
        internal static UserControl AbrirVistaInformes() => new InformesUserControl();

        /// <summary>
        /// Abre la vista anyadir alumno
        /// </summary>
        internal static void AbrirVistaAnyadirAlumno() => new AnyadirAlumno().ShowDialog();

        // INFORMES

        /// <summary>
        /// Abre la vista informe xarxa completo.
        /// </summary>
        internal static void AbrirInformeXarxaCompleto() => new InformeXarxaCompleto().ShowDialog();

        /// <summary>
        /// Abre la vista informe concesion.
        /// </summary>
        internal static void AbrirInformeConcesion() => new InformeConcesion().ShowDialog();

        /// <summary>
        /// Abre la vista informe xarxa grupos.
        /// </summary>
        internal static void AbrirInformeXarxaGrupos() => new InformeXarxaGrupos().ShowDialog();

        /// <summary>
        /// Abre la vista informe recogida.
        /// </summary>
        internal static void AbrirInformeRecogida() => new InformeRecogida().ShowDialog();

        /// <summary>
        /// Abre la vista informe lotes.
        /// </summary>
        internal static void AbrirInformeLotes() => new InformeLotes().ShowDialog();

        /// <summary>
        /// Abrire la vista etiquetas.
        /// </summary>
        internal static void AbrirInformeEtiquetas() => new InformeEtiquetas().ShowDialog();

        /// <summary>
        /// Abre la vista etiquetas bolsa.
        /// </summary>
        internal static void AbrirInformeEtiquetasBolsa() => new InformeEtiquetasBolsa().ShowDialog();

    }
}
