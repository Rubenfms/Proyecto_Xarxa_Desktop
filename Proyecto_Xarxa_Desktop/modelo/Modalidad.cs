using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    /// <summary>
    /// Clase modelo de las distintas modalidades que tienen los libros
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class Modalidad : ObservableObject
    {
        /// <summary>
        /// ID que identifica a la modalidad
        /// </summary>
        private int _id;

        /// <summary>
        /// Gets or sets the id de la Modalidad.
        /// </summary>
        /// <value>
        /// ID que identifica a la modalidad
        /// </value>
        [JsonProperty("idModalidad")]
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        /// <summary>
        /// Nombre de la modalidad
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Gets or sets el nombre de la modalidad.
        /// </summary>
        /// <value>
        /// Nombre de la modalidad
        /// </value>
        [JsonProperty("nombre")]
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        /// <summary>
        /// Lista de libros que tiene esa modalidad
        /// </summary>
        private ObservableCollection<Libro> _librosModalidad;

        /// <summary>
        /// Gets or sets librosModalidad.
        /// </summary>
        /// <value>
        /// Lista de libros que tiene esa modalidad
        /// </value>
        [JsonProperty("libroCollection")]
        public ObservableCollection<Libro> LibrosModalidad
        {
            get { return _librosModalidad; }
            set { SetProperty(ref _librosModalidad, value); }
        }

        /// <summary>
        /// Curso en el que se usa esa modalidad
        /// </summary>
        private string curso;

        /// <summary>
        /// Gets or sets the curso.
        /// </summary>
        /// <value>
        /// Curso en el que se usa esa modalidad
        /// </value>
        [JsonProperty("curso")]
        public string Curso
        {
            get { return curso; }
            set { SetProperty(ref curso, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Modalidad"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="librosModalidad">The libros modalidad.</param>
        /// <param name="curso">The curso.</param>
        public Modalidad(int id, string nombre, ObservableCollection<Libro> librosModalidad, string curso)
        {
            Id = id;
            Nombre = nombre;
            LibrosModalidad = librosModalidad;
            Curso = curso;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
