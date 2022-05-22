using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de LibrosUserControl
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class LibrosVM : ObservableObject
    {
        /// <summary>
        /// The libro seleccionado
        /// </summary>
        private Libro libroSeleccionado;

        /// <summary>
        /// Gets or sets the libro seleccionado.
        /// </summary>
        /// <value>
        /// The libro seleccionado.
        /// </value>
        public Libro LibroSeleccionado
        {
            get { return libroSeleccionado; }
            set { SetProperty(ref libroSeleccionado, value); }
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
        /// La lista de libros que se cargará en la vista
        /// </summary>
        private ObservableCollection<Libro> listaLibros;

        /// <summary>
        /// Gets or sets the lista libros.
        /// </summary>
        /// <value>
        /// La lista de libros que se cargará en la vista
        /// </value>
        public ObservableCollection<Libro> ListaLibros
        {
            get { return listaLibros; }
            set { SetProperty(ref listaLibros, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private ServicioAPI servicioAPI;

        /// <summary>
        /// Gets the anyadir libro command.
        /// </summary>
        /// <value>
        /// The anyadir libro command.
        /// </value>
        public RelayCommand AnyadirLibroCommand { get; }

        /// <summary>
        /// Gets the editar libro command.
        /// </summary>
        /// <value>
        /// The editar libro command.
        /// </value>
        public RelayCommand EditarLibroCommand { get; }

        /// <summary>
        /// Gets the eliminar libro command.
        /// </summary>
        /// <value>
        /// The eliminar libro command.
        /// </value>
        public RelayCommand EliminarLibroCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LibrosVM"/> class.
        /// </summary>
        public LibrosVM()
        {
            UsuarioLogeado = (Usuario)Application.Current.Resources["UsuarioLogeado"];

            // Api
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

            // Carga libros
            ListaLibros = servicioAPI.GetLibros();

            // Comandos
            AnyadirLibroCommand = new RelayCommand(AbrirVistaAnyadirLibro);
            EditarLibroCommand = new RelayCommand(AbrirVistaEditarLibro);
            EliminarLibroCommand = new RelayCommand(EliminarLibro);

        }

        /// <summary>
        /// Abre la vista anyadir libro.
        /// </summary>
        public void AbrirVistaAnyadirLibro()
        {
            ServicioNavegacion.AbrirVistaAnyadirLibro();
        }

        /// <summary>
        /// Abre la vista editar libro.
        /// </summary>
        public void AbrirVistaEditarLibro()
        {

        }

        /// <summary>
        /// Elimina un libro.
        /// </summary>
        public void EliminarLibro()
        {

        }
    }
}
