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
    /// Clase Modelo de los lotes de libros que tienen los alumnos
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class Lote : ObservableObject
    {

        /// <summary>
        /// ID que identifica a cada lote
        /// </summary>
        private int _idLote;

        /// <summary>
        /// Gets or sets the idLote.
        /// </summary>
        /// <value>
        /// ID que identifica a cada lote
        /// </value>
        [JsonProperty("idLote")]
        public int IdLote
        {
            get => _idLote;
            set { _ = SetProperty(field: ref _idLote, value); }
        }

        /// <summary>
        /// Libros que contiene ese lote
        /// </summary>
        private ObservableCollection<LibroXarxa> _librosLote;

        /// <summary>
        /// Gets or sets the libros lote.
        /// </summary>
        /// <value>
        /// Libros que contiene ese lote
        /// </value>
        [JsonProperty("librosLote")]
        public ObservableCollection<LibroXarxa> LibrosLote
        {
            get { return _librosLote; }
            set { SetProperty(ref _librosLote, value); }
        }

        /// <summary>
        /// Modalidad a la que pertenece ese lote
        /// </summary>
        private Modalidad _modalidadLote;

        /// <summary>
        /// Gets or sets the modalidad lote.
        /// </summary>
        /// <value>
        /// Modalidad a la que pertenece ese lote
        /// </value>
        [JsonProperty("modalidadLote")]
        public Modalidad ModalidadLote
        {
            get => _modalidadLote;
            set { _ = SetProperty(field: ref _modalidadLote, value); }
        }

        /// <summary>
        /// Nia del alumno al que pertenece el lote
        /// </summary>
        private int? niaAlumno;

        /// <summary>
        /// Gets or sets the nia alumno.
        /// </summary>
        /// <value>
        /// Nia del alumno al que pertenece el lote
        /// </value>
        [JsonProperty("niaAlumno")]
        public int? NiaAlumno
        {
            get { return niaAlumno; }
            set { SetProperty(ref niaAlumno, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lote"/> class.
        /// </summary>
        /// <param name="idLote">The identifier lote.</param>
        /// <param name="librosLote">The libros lote.</param>
        /// <param name="modalidad">The modalidad.</param>
        /// <param name="niaAlumno">The nia alumno.</param>
        public Lote(int idLote, ObservableCollection<LibroXarxa> librosLote, Modalidad modalidad, int? niaAlumno)
        {
            IdLote = idLote;
            ModalidadLote = modalidad;
            LibrosLote = librosLote;
            NiaAlumno = niaAlumno;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lote"/> class.
        /// </summary>
        /// <param name="idLote">The identifier lote.</param>
        /// <param name="librosLote">The libros lote.</param>
        /// <param name="modalidad">The modalidad.</param>
        public Lote(int idLote, ObservableCollection<LibroXarxa> librosLote, Modalidad modalidad)
        {
            IdLote = idLote;
            ModalidadLote = modalidad;
            LibrosLote = librosLote;
        }

        public Lote(int idLote, Modalidad modalidad)
        {
            IdLote = idLote;
            ModalidadLote = modalidad;
        }

        /// <summary>
        /// Initializes a new empty instance of the <see cref="Lote"/> class.
        /// </summary>
        public Lote()
        {
        }
    }
}
