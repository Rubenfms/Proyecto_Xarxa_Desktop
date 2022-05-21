using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de MainWindow.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class MainWindowVM : ObservableObject
    {
        /// <summary>
        /// The usuario logeado
        /// </summary>
        private Usuario usuarioLogeado;

        /// <summary>
        /// Gets or sets the usuario logeado.
        /// </summary>
        /// <value>
        /// The usuario logeado.
        /// </value>
        public Usuario UsuarioLogeado
        {
            get { return usuarioLogeado; }
            set { SetProperty(ref usuarioLogeado, value); }
        }

        /// <summary>
        /// La pestaña actual en el UserControl.
        /// </summary>
        private UserControl pestanyaActual;

        /// <summary>
        /// Gets or sets the pestanya actual.
        /// </summary>
        /// <value>
        /// La pestaña actual en el UserControl.
        /// </value>
        public UserControl PestanyaActual
        {
            get { return pestanyaActual; }
            set { SetProperty(ref pestanyaActual, value); }
        }

        /// <summary>
        /// Gets the generar lote command.
        /// </summary>
        /// <value>
        /// The generar lote command.
        /// </value>
        public RelayCommand GenerarLoteCommand { get; }

        /// <summary>
        /// Gets the abrir vista lotes command.
        /// </summary>
        /// <value>
        /// The abrir vista lotes command.
        /// </value>
        public RelayCommand AbrirVistaLotesCommand { get; }

        /// <summary>
        /// Gets the abrir vista alumnos command.
        /// </summary>
        /// <value>
        /// The abrir vista alumnos command.
        /// </value>
        public RelayCommand AbrirVistaAlumnosCommand { get; }

        /// <summary>
        /// Gets the abrir vista libros command.
        /// </summary>
        /// <value>
        /// The abrir vista libros command.
        /// </value>
        public RelayCommand AbrirVistaLibrosCommand { get; }
        
        public RelayCommand AbrirVistaInformesCommand { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowVM"/> class.
        /// </summary>
        public MainWindowVM()
        {
            // Instancia vacía para que al iniciar el programa no aparezca ningún UserControl seleccionado
            PestanyaActual = new VistaInicialContentControl();
            UsuarioLogeado = (Usuario)Application.Current.Resources["UsuarioLogeado"];


            // Comandos
            AbrirVistaLotesCommand = new RelayCommand(AbrirVistaLotes);
            AbrirVistaAlumnosCommand = new RelayCommand(AbrirVistaAlumnos);
            AbrirVistaLibrosCommand = new RelayCommand(AbrirVistaLibros);
            GenerarLoteCommand = new RelayCommand(AbrirVistaGenerarLote);
            AbrirVistaInformesCommand = new RelayCommand(AbrirVistaInformes);
        }

        /// <summary>
        /// Carga la vista de lotes en el UserControl.
        /// </summary>
        public void AbrirVistaLotes() => PestanyaActual = ServicioNavegacion.AbrirVistaLotes();

        /// <summary>
        /// Carga la vista de alumnos en el UserControl.
        /// </summary>
        public void AbrirVistaAlumnos() => PestanyaActual = ServicioNavegacion.AbrirVistaAlumnos();

        /// <summary>
        /// Carga la vista libros en el UserControl.
        /// </summary>
        public void AbrirVistaLibros() => PestanyaActual = ServicioNavegacion.AbrirVistaLibros();

        /// <summary>
        /// Abre la ventana de opciones de super usuario.
        /// </summary>
        public void AbrirOpcionesSU() => ServicioNavegacion.AbrirVistaOpcionesSU();

        /// <summary>
        /// Cierra la sesión actual y nos devuelve a la pantalla de Log In.
        /// </summary>
        public void CerrarSesion()
        {
            ServicioNavegacion.AbrirVistaLogIn();
            UsuarioLogeado = new Usuario();
        }

        /// <summary>
        /// Abre la vista generar lote.
        /// </summary>
        public void AbrirVistaGenerarLote() => ServicioNavegacion.AbrirVistaGenerarLote();

        /// <summary>
        /// Abre la vista dar de alta alumno.
        /// </summary>
        public void AbrirVistaDarDeAltaAlumno() => ServicioNavegacion.AbrirVistaDarDeAlta();

        /// <summary>
        /// Abrir la vista añadir alumno.
        /// </summary>
        public void AbrirVistaAnyadirAlumno() => ServicioNavegacion.AbrirVistaAnyadirAlumno();

        /// <summary>
        /// Abrir la vista informes.
        /// </summary>
        public void AbrirVistaInformes() => PestanyaActual = ServicioNavegacion.AbrirVistaInformes();

    }
}
