using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    /// <summary>
    /// Clase modelo para las etiquetas
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class LoteInformeEtiquetas : ObservableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoteInformeEtiquetas"/> class.
        /// </summary>
        /// <param name="idLote">The identifier lote.</param>
        /// <param name="curso">The curso.</param>
        public LoteInformeEtiquetas(int idLote, string curso)
        {
            IdLote = idLote;
            Curso = curso;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoteInformeEtiquetas"/> class.
        /// </summary>
        /// <param name="idLote">The identifier lote.</param>
        /// <param name="curso">The curso.</param>
        /// <param name="nombreAlumno">The nombre alumno.</param>
        public LoteInformeEtiquetas(int idLote, string curso, string nombreAlumno)
        {
            IdLote = idLote;
            Curso = curso;
            NombreAlumno = nombreAlumno;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoteInformeEtiquetas"/> class.
        /// </summary>
        public LoteInformeEtiquetas() { }

        /// <summary>
        /// El nombre del alumno.
        /// </summary>
        private string _nombreAlumno;

        /// <summary>
        /// Gets or sets el nombre del alumno.
        /// </summary>
        /// <value>
        /// El nombre del alumno.
        /// </value>
        public string NombreAlumno
        {
            get => _nombreAlumno;
            set { SetProperty(ref _nombreAlumno, value); }
        }

        /// <summary>
        /// El identificador del lote
        /// </summary>
        private int _idLote;

        /// <summary>
        /// Gets or sets el identificador del lote.
        /// </summary>
        /// <value>
        /// El identificador del lote.
        /// </value>
        public int IdLote
        {
            get => _idLote;
            set { SetProperty(ref _idLote, value); }
        }

        /// <summary>
        /// El curso del alumno.
        /// </summary>
        private string _curso;

        /// <summary>
        /// Gets or sets the curso.
        /// </summary>
        /// <value>
        /// El curso del alumno.
        /// </value>
        public string Curso
        {
            get => _curso;
            set { SetProperty(ref _curso, value); }
        }

    }
}
