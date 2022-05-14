using Microsoft.Toolkit.Mvvm.ComponentModel;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Initializes a new instance of the <see cref="LibrosVM"/> class.
        /// </summary>
        public LibrosVM()
        {
            // Api
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

            // Carga libros
            ListaLibros = servicioAPI.GetLibros();
        }
    }
}
