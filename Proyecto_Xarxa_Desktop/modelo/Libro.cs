using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Ola
/// </summary>
namespace Proyecto_Xarxa_Desktop.modelo
{
    /// <summary>
    /// Clase modelo de los libros generales que se utilizan en los distintos cursos
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class Libro : ObservableObject
    {
        /// <summary>
        /// Isbn que identifica al libro
        /// </summary>
        private string _isbn;

        /// <summary>
        /// Gets or sets el isbn que identifica al libro
        /// </summary>
        /// <value>
        /// Isbn que identifica al libro
        /// </value>
        [JsonProperty("isbnLibro")]
        public string Isbn
        {
            get { return _isbn; }
            set { SetProperty(ref _isbn, value); }
        }

        /// <summary>
        /// Título del libro.
        /// </summary>
        private string _titulo;

        /// <summary>
        /// Gets or sets el título del libro
        /// </summary>
        /// <value>
        /// Título del libro.
        /// </value>
        [JsonProperty("titulo")]
        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }

        /// <summary>
        /// Curso al que pertenece el libro
        /// </summary>
        private string _curso;

        /// <summary>
        /// Gets or sets el curso al que pertenece el libro.
        /// </summary>
        /// <value>
        /// Curso al que pertenece el libro
        /// </value>
        [JsonProperty("curso")]
        public string Curso
        {
            get { return _curso; }
            set { SetProperty(ref _curso, value); }
        }

        /// <summary>
        /// Departamento al que pertenece el libro.
        /// </summary>
        private string _departamento;

        /// <summary>
        /// Gets or sets el departamento al que pertenece el libro..
        /// </summary>
        /// <value>
        /// El departamento al que pertenece el libro..
        /// </value>
        [JsonProperty("departamento")]
        public string Departamento
        {
            get { return _departamento; }
            set { SetProperty(ref _departamento, value); }
        }

        /// <summary>
        /// La editorial a la que pertenece el libro.
        /// </summary>
        private string _editorial;

        /// <summary>
        /// Gets or sets la editorial a la que pertenece el libro.
        /// </summary>
        /// <value>
        /// Editorial al que pertenece el libro.
        /// </value>
        [JsonProperty("editorial")]
        public string Editorial
        {
            get { return _editorial; }
            set { SetProperty(ref _editorial, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Libro"/> class.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        /// <param name="titulo">The titulo.</param>
        /// <param name="curso">The curso.</param>
        /// <param name="departamento">The departamento.</param>
        /// <param name="editorial">The editorial.</param>
        public Libro(string isbn, string titulo, string curso, string departamento, string editorial)
        {
            Isbn = isbn;
            Titulo = titulo;
            Curso = curso;
            Departamento = departamento;
            Editorial = editorial;
        }

        /// <summary>
        /// Initializes a new empty instance of the <see cref="Libro"/> class.
        /// </summary>
        public Libro()
        {

        }

        public override string ToString()
        {
            return Isbn + " - " + Titulo + " - " + Editorial;
        }

    }
}
