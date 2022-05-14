using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Proyecto_Xarxa_Desktop.modelo
{
    /// <summary>
    /// Clase modelo de los libros ÚNICOS que pertenecen a los lotes y que tienen los alumnos.
    /// Hereda de la clase Libro (libros generales)
    /// </summary>
    /// <seealso cref="Proyecto_Xarxa_Desktop.modelo.Libro" />
    class LibroXarxa : Libro
    {
        /// <summary>
        /// Codigo que identifica a cada Libro Xarxa
        /// </summary>
        private int _codigoXarxa;

        /// <summary>
        /// Gets or sets the codigo xarxa.
        /// </summary>
        /// <value>
        /// Codigo que identifica a cada Libro Xarxa
        /// </value>
        [JsonProperty("codigoXarxa")]
        public int CodigoXarxa
        {
            get { return _codigoXarxa; }
            set { SetProperty(ref _codigoXarxa, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LibroXarxa"/> class.
        /// </summary>
        /// <param name="codigoXarxa">The codigo xarxa.</param>
        /// <param name="isbn">The isbn.</param>
        /// <param name="titulo">The titulo.</param>
        /// <param name="curso">The curso.</param>
        /// <param name="departamento">The departamento.</param>
        /// <param name="editorial">The editorial.</param>
        public LibroXarxa(int codigoXarxa, string isbn, string titulo, string curso, string departamento, string editorial) : base(isbn, titulo, curso, departamento, editorial)
        {
            CodigoXarxa = codigoXarxa;
        }

        /// <summary>
        /// Initializes a new empty instance of the <see cref="LibroXarxa"/> class.
        /// </summary>
        public LibroXarxa()
        {

        }

    }
}
