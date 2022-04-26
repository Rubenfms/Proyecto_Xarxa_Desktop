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
    class Modalidad:ObservableObject
    {
        private int _id;

        [JsonProperty("idModalidad")]
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private ObservableCollection<Libro> _librosModalidad;

        [JsonProperty("libroCollection")]
        public ObservableCollection<Libro> LibrosModalidad
        {
            get { return _librosModalidad; }
            set { SetProperty(ref _librosModalidad, value); }
        }

        private string curso;

        public string Curso
        {
            get { return curso; }
            set { SetProperty(ref curso, value); }
        }

        public Modalidad(int id, string nombre, ObservableCollection<Libro> librosModalidad, string curso)
        {
            Id = id;
            Nombre = nombre;
            LibrosModalidad = librosModalidad;
            Curso = curso;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
