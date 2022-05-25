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
    class AnyadirLibroVM : ObservableObject
    {
        /// <summary>
        /// Libro que vamos a crear a través de los datos introducidos en el formulario.
        /// </summary>
        private Libro libroSel;

        /// <summary>
        /// Gets or sets the libro sel.
        /// </summary>
        /// <value>
        /// Libro que vamos a crear a través de los datos introducidos en el formulario.
        /// </value>
        public Libro LibroSel
        {
            get { return libroSel; }
            set { SetProperty(ref libroSel, value); }
        }

        /// <summary>
        /// The servicio API.
        /// </summary>
        private readonly ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyadirLibroVM"/> class.
        /// </summary>
        public AnyadirLibroVM()
        {
            LibroSel = new Libro();
        }

        /// <summary>
        /// Método que comprueba los campos y si están todos correctos añade  el libro.
        /// </summary>
        public bool AnyadirLibro()
        {
            if(ComprobarDatosIntroducidos())
            {
                HttpStatusCode? statusCode = servicioAPI.PostLibro(libroSel);
                ServicioDialogos.ServicioMessageBox($"Resultado del alta del libro: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.Created));
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Comprueba los datos introducidos en el formulario.
        /// </summary>
        /// <returns>true si todos los datos introducidos o false si algún dato érroneo</returns>
        public bool ComprobarDatosIntroducidos()
        {
            bool isbnSoloNumeros = long.TryParse(LibroSel.Isbn, out _);

            if (LibroSel.Isbn == null || !isbnSoloNumeros || LibroSel.Isbn.Length < 10)
            {
                ServicioDialogos.ServicioMessageBox("El formato de ISBN introducido no es válido. Prueba a introducir solo números y que el ISBN sea mayor de 10 digitos. (Ej:978963516711)", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSel.Titulo == null || LibroSel.Titulo.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el título del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSel.Curso == null || LibroSel.Curso.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el curso en el que se usará el libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSel.Editorial == null || LibroSel.Editorial.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce la editorial del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (LibroSel.Departamento == null || LibroSel.Departamento.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el departamento del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else return true;

        }
    }
}
