using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de EditarLibroDialog
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class EditarLibroVM : ObservableObject
    {
        /// <summary>
        /// El libro que vamos a editar (recibido desde la pantalla libros).
        /// </summary>
        private Libro libroSeleccionado;

        /// <summary>
        /// Gets or sets el libro seleccionado.
        /// </summary>
        /// <value>
        /// El libro que vamos a editar (recibido desde la pantalla libros).
        /// </value>
        public Libro LibroSeleccionado
        {
            get { return libroSeleccionado; }
            set { SetProperty(ref libroSeleccionado, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private readonly ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="EditarLibroVM"/> class.
        /// </summary>
        public EditarLibroVM()
        {
            // Recibimos el alumno del que queremos ver las incidencias
            LibroSeleccionado = WeakReferenceMessenger.Default.Send<EditarLibroRequestMessage>();
        }

        /// <summary>
        /// Método que comprueba el formulario y edita el libro si los datos introducidos son correctos.
        /// </summary>
        /// <returns></returns>
        public bool EditarLibro()
        {
            if (ComprobarDatosIntroducidos())
            {
                HttpStatusCode? statusCode = servicioAPI.PutLibro(LibroSeleccionado);
                ServicioDialogos.ServicioMessageBox($"Resultado de la edición del libro: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Comrpueba los datos introducidos.
        /// </summary>
        /// <returns>true si todos los datos introducidos o false si algún dato érroneo</returns>
        public bool ComprobarDatosIntroducidos()
        {
            if (LibroSeleccionado.Isbn == null || !long.TryParse(LibroSeleccionado.Isbn, out _))
            {
                ServicioDialogos.ServicioMessageBox("El formato de ISBN introducido no es válido (Ej:978963516711). Prueba a introducir solo números y que el ISBN sea mayor de 10 digitos.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSeleccionado.Titulo == null || LibroSeleccionado.Titulo.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el título del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSeleccionado.Curso == null || LibroSeleccionado.Curso.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el curso en el que se usará el libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSeleccionado.Editorial == null || LibroSeleccionado.Editorial.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce la editorial del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSeleccionado.Departamento == null || LibroSeleccionado.Departamento.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el departamento del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else return true;
        }
    }
}
