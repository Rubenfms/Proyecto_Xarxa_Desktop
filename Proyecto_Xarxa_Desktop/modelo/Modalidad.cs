using Microsoft.Toolkit.Mvvm.ComponentModel;
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

        public ObservableCollection<Libro> LibrosModalidad
        {
            get { return _librosModalidad; }
            set { SetProperty(ref _librosModalidad, value); }
        }
    }
}
