using Microsoft.Toolkit.Mvvm.ComponentModel;
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
        /// ISBN que identifica al libro.
        /// </summary>
        private string isbn;

        /// <summary>
        /// Gets or sets el isbn.
        /// </summary>
        /// <value>
        /// ISBN que identifica al libro.
        /// </value>
        public string Isbn
        {
            get { return isbn; }
            set { SetProperty(ref isbn, value); }
        }

        /// <summary>
        /// El titulo del libro.
        /// </summary>
        private string titulo;

        /// <summary>
        /// Gets or sets el titulo del libro.
        /// </summary>
        /// <value>
        /// El titulo del libro.
        /// </value>
        public string Titulo
        {
            get { return titulo; }
            set { SetProperty(ref titulo, value); }
        }

        /// <summary>
        /// Curso en el que se usará el libro.
        /// </summary>
        private string curso;

        /// <summary>
        /// Gets or sets el curso del libro.
        /// </summary>
        /// <value>
        /// Curso en el que se usará el libro.
        /// </value>
        public string Curso
        {
            get { return curso; }
            set { SetProperty(ref curso, value); }
        }

        /// <summary>
        /// La editorial del libro.
        /// </summary>
        private string editorial;

        /// <summary>
        /// Gets or sets la editorial.
        /// </summary>
        /// <value>
        /// La editorial del libro.
        /// </value>
        public string Editorial
        {
            get { return editorial; }
            set { SetProperty(ref editorial, value); }
        }

        /// <summary>
        /// El departamento al que pertenece el libro
        /// </summary>
        private string departamento;

        /// <summary>
        /// Gets or sets el departamento del libro.
        /// </summary>
        /// <value>
        /// El departamento al que pertenece el libro.
        /// </value>
        public string Departamento
        {
            get { return departamento; }
            set { SetProperty(ref departamento, value); }
        }

        /// <summary>
        /// The servicio API.
        /// </summary>
        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyadirLibroVM"/> class.
        /// </summary>
        public AnyadirLibroVM()
        {

        }

        /// <summary>
        /// Método que comprueba los campos y si están todos correctos añade  el libro.
        /// </summary>
        public bool AnyadirLibro()
        {
            if(ComprobarDatosIntroducidos())
            {
                HttpStatusCode? statusCode = servicioAPI.PostLibro(new Libro(Isbn, Titulo, Curso, Departamento, Editorial));
                ServicioDialogos.ServicioMessageBox($"Resultado del alta del libro: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (Isbn == null || !Int32.TryParse(Isbn, out _))
            {
                ServicioDialogos.ServicioMessageBox("El formato de ISBN introducido no es válido (Ej:978963516711). Prueba a introducir solo números y que el ISBN sea mayor de 10 digitos.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Titulo == null || Titulo.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el título del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Curso == null || Curso.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el curso en el que se usará el libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Editorial == null || Editorial.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce la editorial del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Departamento == null || Departamento.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce el departamento del libro.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else return true;

        }
    }
}
