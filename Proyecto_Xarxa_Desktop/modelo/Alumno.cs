using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Proyecto_Xarxa_Desktop.enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{

    /// <summary>
    /// Clase Modelo de alumno
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class Alumno : ObservableObject
    {

        /// <summary>
        /// Lote que pertenece al alumno
        /// </summary>
        private Lote _lote;

        /// <summary>
        /// Gets or sets lote que pertenece al alumno.
        /// </summary>
        /// <value>
        /// Lote que pertenece al alumno
        /// </value>
        [JsonProperty("loteCollection")]
        public Lote Lote
        {
            get { return _lote; }
            set { SetProperty(ref _lote, value); }
        }

        /// <summary>
        /// Nia que identifica al alumno.
        /// </summary>
        private int _nia;

        /// <summary>
        /// Gets or sets the nia.
        /// </summary>
        /// <value>
        /// Nia que identifica al alumno.
        /// </value>
        [JsonProperty("nia")]
        public int Nia
        {
            get { return _nia; }
            set { SetProperty(ref _nia, value); }
        }

        /// <summary>
        /// Nombre del alumno.
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Gets or sets el nombre del alumno.
        /// </summary>
        /// <value>
        /// Nombre del alumno.
        /// </value>
        [JsonProperty("nombre")]
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        /// <summary>
        /// Primer apellido del alumno.
        /// </summary>
        private string _apellido1;

        /// <summary>
        /// Gets or sets el primer apellido del alumno.
        /// </summary>
        /// <value>
        /// Primer apellido del alumno.
        /// </value>
        [JsonProperty("apellido1")]
        public string Apellido1
        {
            get { return _apellido1; }
            set { SetProperty(ref _apellido1, value); }
        }

        /// <summary>
        /// Segundo apellido del alumno.
        /// </summary>
        private string _apellido2;

        /// <summary>
        /// Gets or sets el segundo apellido del alumno.
        /// </summary>
        /// <value>
        /// Segundo apellido del alumno.
        /// </value>
        [JsonProperty("apellido2")]
        public string Apellido2
        {
            get { return _apellido2; }
            set { SetProperty(ref _apellido2, value); }
        }

        /// <summary>
        /// Estado de la matricula del alumno.
        /// </summary>
        private string _matricula;

        /// <summary>
        /// Gets or sets el stado de la matricula del alumno.
        /// </summary>
        /// <value>
        /// Estado de la matricula del alumno.
        /// </value>
        [JsonProperty("estadoMatriculacion")]
        public string Matricula
        {
            get { return _matricula; }
            set { SetProperty(ref _matricula, value); }
        }

        /// <summary>
        /// El curso del alumno
        /// </summary>
        private string _curso;

        /// <summary>
        /// Gets or sets el curso del alumno.
        /// </summary>
        /// <value>
        /// El curso del alumno
        /// </value>
        [JsonProperty("curso")]
        public string Curso
        {
            get { return _curso; }
            set { SetProperty(ref _curso, value); }
        }

        /// <summary>
        /// Grupo del alumno
        /// </summary>
        private string _grupo;

        /// <summary>
        /// Gets or sets el grupo del alumno.
        /// </summary>
        /// <value>
        /// El grupo del alumno
        /// </value>
        [JsonProperty("grupo")]
        public string Grupo
        {
            get { return _grupo; }
            set { SetProperty(ref _grupo, value); }
        }

        /// <summary>
        /// Incidencias del alumno
        /// </summary>
        private string _incidencias;

        /// <summary>
        /// Gets or sets incidencias.
        /// </summary>
        /// <value>
        /// Incidencias del alumno.
        /// </value>
        [JsonProperty("incidencias")]
        public string Incidencias
        {
            get { return _incidencias; }
            set { SetProperty(ref _incidencias, value); }
        }

        /// <summary>
        /// Booleano que controla si el alumno pertenece a la xarxa o no
        /// </summary>
        private bool _perteneceXarxa;

        /// <summary>
        /// Gets or sets a value indicating whether [pertenece xarxa].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pertenece xarxa]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("perteneceXarxa")]
        public bool PerteneceXarxa
        {
            get { return _perteneceXarxa; }
            set { SetProperty(ref _perteneceXarxa, value); }
        }

        /// <summary>
        /// Identificador del lote que le pertenece al Alumno
        /// </summary>
        private int idLote;

        /// <summary>
        /// Gets or sets the identifier lote.
        /// </summary>
        /// <value>
        /// Identificador del lote que le pertenece al Alumno
        /// </value>
        [JsonProperty("idLote")]
        public int IdLote
        {
            get { return idLote; }
            set { SetProperty(ref idLote, value); }
        }

        private bool _concesion;

        public bool Concesion
        {
            get { return _concesion; }
            set { SetProperty(ref _concesion, value); }
        }

        // Constructor copia       
        /// <summary>
        /// Initializes a new instance of the <see cref="Alumno"/> class. without Lote
        /// </summary>
        public Alumno(Alumno alumno)
        {
            Nia = alumno.Nia;
            Nombre = alumno.Nombre;
            Apellido1 = alumno.Apellido1;
            Apellido2 = alumno.Apellido2;
            Matricula = alumno.Matricula;
            Curso = alumno.Curso;
            Grupo = alumno.Grupo;
            Incidencias = alumno.Incidencias;
            PerteneceXarxa = alumno.PerteneceXarxa;
        }

        // Constructor sin lote        
        /// <summary>
        /// Initializes a new instance of the <see cref="Alumno"/> class. without Lote
        /// </summary>
        /// <param name="nia">The nia.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="apellido1">The apellido1.</param>
        /// <param name="apellido2">The apellido2.</param>
        /// <param name="matricula">The matricula.</param>
        /// <param name="curso">The curso.</param>
        /// <param name="grupo">The grupo.</param>
        /// <param name="incidencias">The incidencias.</param>
        /// <param name="perteneceXarxa">if set to <c>true</c> [pertenece xarxa].</param>
        public Alumno(int nia, string nombre, string apellido1, string apellido2, string matricula, string curso, string grupo, string incidencias, bool perteneceXarxa)
        {
            Nia = nia;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Matricula = matricula;
            Curso = curso;
            Grupo = grupo;
            Incidencias = incidencias;
            PerteneceXarxa = perteneceXarxa;
        }

        // Constructor con lote        
        /// <summary>
        /// Initializes a new instance of the <see cref="Alumno"/> class. with Lote
        /// </summary>
        /// <param name="nia">The nia.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="apellido1">The apellido1.</param>
        /// <param name="apellido2">The apellido2.</param>
        /// <param name="matricula">The matricula.</param>
        /// <param name="curso">The curso.</param>
        /// <param name="grupo">The grupo.</param>
        /// <param name="incidencias">The incidencias.</param>
        /// <param name="perteneceXarxa">if set to <c>true</c> [pertenece xarxa].</param>
        /// <param name="lote">The lote.</param>
        public Alumno(int nia, string nombre, string apellido1, string apellido2, string matricula, string curso, string grupo, string incidencias, bool perteneceXarxa, Lote lote)
        {
            Nia = nia;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Matricula = matricula;
            Curso = curso;
            Grupo = grupo;
            Incidencias = incidencias;
            PerteneceXarxa = perteneceXarxa;
            Lote = lote;
        }

        // Constructor sin lote y sin PerteneceXarxa
        /// <summary>Initializes a new instance of the <see cref="Alumno" /> class. without lote and without PerteneceXarxa</summary>
        /// <param name="nia">The nia.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="apellido1">The apellido1.</param>
        /// <param name="apellido2">The apellido2.</param>
        /// <param name="matricula">The matricula.</param>
        /// <param name="curso">The curso.</param>
        /// <param name="grupo">The grupo.</param>
        /// <param name="incidencias">The incidencias.</param>
        public Alumno(int nia, string nombre, string apellido1, string apellido2, string matricula, string curso, string grupo, string incidencias)
        {
            Nia = nia;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Matricula = matricula;
            Curso = curso;
            Grupo = grupo;
            Incidencias = incidencias;
        }


        /// <summary>Initializes a new empty instance of the <see cref="Alumno" /> class.</summary>
        public Alumno()
        {
        }

        // Constructor con IdLote
        /// <summary>Initializes a new instance of the <see cref="Alumno" /> class. with IdLote</summary>
        /// <param name="nia">The nia.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="apellido1">The apellido1.</param>
        /// <param name="apellido2">The apellido2.</param>
        /// <param name="matricula">The matricula.</param>
        /// <param name="curso">The curso.</param>
        /// <param name="grupo">The grupo.</param>
        /// <param name="incidencias">The incidencias.</param>
        /// <param name="perteneceXarxa">if set to <c>true</c> [pertenece xarxa].</param>
        /// <param name="idLote">The identifier lote.</param>
        public Alumno(int nia, string nombre, string apellido1, string apellido2, string matricula, string curso, string grupo, string incidencias, bool perteneceXarxa, int idLote)
        {
            Nia = nia;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Matricula = matricula;
            Curso = curso;
            Grupo = grupo;
            Incidencias = incidencias;
            PerteneceXarxa = perteneceXarxa;
            IdLote = idLote;
        }
    }
}
