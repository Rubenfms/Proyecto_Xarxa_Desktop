using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de AlumnosUserControl.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class AlumnosVM : ObservableObject
    {
        /// <summary>Lista de alumnos que recibimos de la API.</summary>
        private ObservableCollection<Alumno> listaAlumnos;

        /// <summary>Propiedad de la lista de alumnos que recibimos de la API.</summary>
        public ObservableCollection<Alumno> ListaAlumnos
        {
            get { return listaAlumnos; }
            set { SetProperty(ref listaAlumnos, value); }
        }


        /// <summary>Alumno seleccionado en el ListView</summary>
        private Alumno alumnoSeleccionado;

        /// <summary>Propiedad del Alumno seleccionado en el ListView</summary>
        public Alumno AlumnoSeleccionado
        {
            get { return alumnoSeleccionado; }
            set { SetProperty(ref alumnoSeleccionado, value); }
        }

        /// <summary>Cadena que se está pasando en el buscador.</summary>
        private string buscador;

        /// <summary>Propiedad de la cadena que se está pasando en el buscador.</summary>
        public string Buscador
        {
            get { return buscador; }
            set { SetProperty(ref buscador, value); }
        }

        /// <summary>
        /// El usuario logeado
        /// </summary>
        private Usuario usuarioLogeado;

        /// <summary>
        /// Gets or sets el usuario logeado.
        /// </summary>
        /// <value>
        /// El usuario logeado.
        /// </value>
        public Usuario UsuarioLogeado
        {
            get { return usuarioLogeado; }
            set { SetProperty(ref usuarioLogeado, value); }
        }

        /// <summary>
        /// Campo del servicio para la API.
        /// </summary>
        private ServicioAPI servicioAPI;

        // Comandos

        /// <summary>Comando dar de alta.</summary>
        /// <value>Comando para el botón de dar de alta.</value>
        public RelayCommand DarDeAltaCommand { get; }

        /// <summary>Comando ver lote del alumno.</summary>
        /// <value>Comando para el botón de ver lote.</value>
        public RelayCommand VerLoteAlumnoCommand { get; }

        /// <summary>Comando ver incidencias del alumno.</summary>
        /// <value>Comando para el botón de ver incidencias.</value>
        public RelayCommand VerIncidenciasCommand { get; }

        /// <summary>Comando para añadir alumno nuevo.</summary>
        /// <value>Comando para añadir alumno nuevo.</value>
        public RelayCommand AnyadirAlumnoCommand { get; }

        /// <summary>Comando para editar un alumno</summary>
        /// <value>Comando para editar un alumno</value>
        public RelayCommand EditarAlumnoCommand { get; }

        public RelayCommand LimpiarSeleccionCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlumnosVM"/> class.
        /// </summary>
        public AlumnosVM()
        {
            UsuarioLogeado = (Usuario)Application.Current.Resources["UsuarioLogeado"];
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaAlumnos = servicioAPI.GetAlumnos();
            //ListaAlumnos = ServicioCsv.GetListaAlumnosFromCSV();
            EsperarCambioEnLaLista();
            // Comandos
            DarDeAltaCommand = new RelayCommand(DarDeAlta);
            VerLoteAlumnoCommand = new RelayCommand(VerLoteAlumno);
            VerIncidenciasCommand = new RelayCommand(VerIncidenciasAlumno);
            AnyadirAlumnoCommand = new RelayCommand(AnyadirAlumno);
            EditarAlumnoCommand = new RelayCommand(EditarAlumno);
            LimpiarSeleccionCommand = new RelayCommand(LimpiarSeleccion);

            // Mensajeria Ver Lote
            try
            {
                // Suscripción para mandar el alumno a ver lote
                WeakReferenceMessenger.Default.Register<AlumnosVM, VerLoteRequestMessage>
                    (this, (r, m) =>
                    {
                        if (!m.HasReceivedResponse) m.Reply(servicioAPI.GetLote(AlumnoSeleccionado.IdLote));
                    });
            }
            // Para que no salte error de null reference (controlado con dialogo en front)
            catch (NullReferenceException)
            {

            }

            // Mensajeria Ver Incidencias

            // Suscripción para mandar el alumno a Ver Incidencias
            WeakReferenceMessenger.Default.Register<AlumnosVM, AlumnoSeleccionadoRequestMessage>
                (this, (r, m) =>
                {
                    if (!m.HasReceivedResponse) m.Reply(AlumnoSeleccionado);
                });
        }

        public void AnyadirAlumno() => ServicioNavegacion.AbrirVistaAnyadirAlumno();
        public void EditarAlumno() => ServicioNavegacion.AbrirVistaEditarAlumno();
        public void LimpiarSeleccion() => AlumnoSeleccionado = null;

        private void EsperarCambioEnLaLista()
        {
            WeakReferenceMessenger.Default.Register<DatoAñadidoOModificadoMessage>(this, (r, m) =>
            {
                if (m.Value)
                {
                    ListaAlumnos = servicioAPI.GetAlumnos();
                }
            });
        }

        /// <summary>
        /// Método que abre ventana de dar de alta al pulsar el botón "Dar de alta"
        /// </summary>
        public void DarDeAlta()
        {
            ServicioNavegacion.AbrirVistaDarDeAlta();
        }

        /// <summary>
        /// Da de baja de la xarxa a un alumno seleccionado
        /// </summary>
        public void DarDeBaja()
        {
            try
            {
                if (!AlumnoSeleccionado.PerteneceXarxa)
                {
                    ServicioDialogos.ServicioMessageBox("El alumno seleccionado no pertenece a la Xarxa", "Alumno no dado de alta", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                else
                {
                    // Mostramos un dialogo preguntando si está seguro de dar de baja
                    MessageBoxResult resultDialog = ServicioDialogos.ServicioMessageBoxResult($"Seguro que quieres dar de baja al alumno con NIA: {AlumnoSeleccionado.Nia}", "¿Estas seguro?", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);

                    // Si selecciona que si damos de baja el alumno
                    if (resultDialog.Equals(MessageBoxResult.Yes))
                    {
                        AlumnoSeleccionado.PerteneceXarxa = false;
                        HttpStatusCode? statusCode = servicioAPI.PutAlumno(AlumnoSeleccionado);
                        ServicioDialogos.ServicioMessageBox($"Resultado de la baja del alumno: {statusCode}", "Resultado baja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            catch (NullReferenceException)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un alumno para ver darle de baja de la xarxa", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Abre una instancia del dialogo ver lote al pulsar el botón ver Lote.
        /// </summary>
        public void VerLoteAlumno()
        {
            try
            {

                ServicioNavegacion.AbrirVistaVerLoteAlumno();

            }
            catch (NullReferenceException)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un alumno para ver su lote", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Abre una instancia del diálogo de ver incidencias.
        /// </summary>
        public void VerIncidenciasAlumno()
        {
            ServicioNavegacion.AbrirVistaVerIncidenciasAlumno();
        }
    }
}
