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
    class Alumno:ObservableObject
    {
        private Lote _lote;

        [JsonProperty("loteCollection")]
        public Lote Lote
        {
            get { return _lote; }
            set { SetProperty(ref _lote, value); }
        }

        private int _nia;

        [JsonProperty("nia")]
        public int Nia
        {
            get { return _nia; }
            set { SetProperty(ref _nia, value); }
        }

        private string _nombre;

        [JsonProperty("nombre")]
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _apellido1;

        [JsonProperty("apellido1")]
        public string Apellido1
        {
            get { return _apellido1; }
            set { SetProperty(ref _apellido1, value); }
        }

        private string _apellido2;

        [JsonProperty("apellido2")]
        public string Apellido2
        {
            get { return _apellido2; }
            set { SetProperty(ref _apellido2, value); }
        }

        private string _matricula;

        [JsonProperty("estadoMatriculacion")]
        public string Matricula
        {
            get { return _matricula; }
            set { SetProperty(ref _matricula, value); }
        }

        private string _curso;

        [JsonProperty("curso")]
        public string Curso
        {
            get { return _curso; }
            set { SetProperty(ref _curso, value); }
        }

        private string _grupo;

        [JsonProperty("grupo")]
        public string Grupo
        {
            get { return _grupo; }
            set { SetProperty(ref _grupo, value); }
        }

        private string _incidencias;

        [JsonProperty("incidencias")]
        public string Incidencias
        {
            get { return _incidencias; }
            set { SetProperty(ref _incidencias, value); }
        }

        private bool _perteneceXarxa;

        [JsonProperty("perteneceXarxa")]
        public bool PerteneceXarxa
        {
            get { return _perteneceXarxa; }
            set { SetProperty(ref _perteneceXarxa, value); }
        }


        [JsonProperty("idLote")]
        private int idLote;

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

        // Constructor sin lote
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

        public Alumno()
        {
        }

        // Constructor con IdLote
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
