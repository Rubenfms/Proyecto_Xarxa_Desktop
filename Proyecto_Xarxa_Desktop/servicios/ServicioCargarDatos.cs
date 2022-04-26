using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.servicios
{
    class ServicioCargarDatos
    {
        private static ObservableCollection<Lote> listaLotes;

        public static ObservableCollection<Lote> ListaLotes
        {
            get { return listaLotes; }
            set { listaLotes = value; }
        }

        private static ObservableCollection<Alumno> listaAlumnos;

        public static ObservableCollection<Alumno> ListaAlumnos
        {
            get { return listaAlumnos; }
            set { listaAlumnos = value; }
        }

        private static ObservableCollection<Modalidad> listaModalidades;

        public static ObservableCollection<Modalidad> ListaModalidades
        {
            get { return listaModalidades; }
            set { listaModalidades = value; }
        }

        private static ObservableCollection<Usuario> listaUsuarios;

        public static ObservableCollection<Usuario> ListaUsuarios
        {
            get { return listaUsuarios; }
            set { listaUsuarios = value; }
        }


        public static void CargarDatos()
        {
            ListaAlumnos = ServicioCsv.GetListaAlumnos();
        }
    }
}
