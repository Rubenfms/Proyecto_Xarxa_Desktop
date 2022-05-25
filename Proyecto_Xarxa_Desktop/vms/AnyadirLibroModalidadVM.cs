using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
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
    /// VM de AnyadirLibroModalidadDialog
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class AnyadirLibroModalidadVM : ObservableObject
    {
        /// <summary>
        /// Lista de libros disponibles.
        /// </summary>
        private ObservableCollection<Libro> listaLibros;

        /// <summary>
        /// Gets or sets the lista libros.
        /// </summary>
        /// <value>
        /// Lista de libros disponibles.
        /// </value>
        public ObservableCollection<Libro> ListaLibros
        {
            get { return listaLibros; }
            set { SetProperty(ref listaLibros, value); }
        }

        /// <summary>
        /// El libro seleccionado
        /// </summary>
        private Libro libroSeleccionado;

        /// <summary>
        /// Gets or sets the libro seleccionado.
        /// </summary>
        /// <value>
        /// El libro seleccionado.
        /// </value>
        public Libro LibroSeleccionado
        {
            get { return libroSeleccionado; }
            set { libroSeleccionado = value; }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private readonly ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyadirLibroModalidadVM"/> class.
        /// </summary>
        public AnyadirLibroModalidadVM()
        {
            // Lista libros
            ListaLibros = servicioAPI.GetLibros();
        }

        /// <summary>
        /// Manda un libro a la ventana de crear modalidad para que lo añada.
        /// </summary>
        public void AnyadirLibro()
        {
            if (LibroSeleccionado != null)
            {
                WeakReferenceMessenger.Default.Send(new AnyadirLibroAModalidadMessage(LibroSeleccionado));
                ServicioDialogos.ServicioMessageBoxWithoutImage("Libro añadido", "Libro Añadido", System.Windows.MessageBoxButton.OK);

            }
            else ServicioDialogos.ServicioMessageBox("Selecciona un libro para añadirlo a la modalidad.", "Selecciona un libro primero", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}
