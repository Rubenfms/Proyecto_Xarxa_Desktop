using Microsoft.Toolkit.Mvvm.ComponentModel;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class AlumnosVM : ObservableObject
    {
        private ObservableCollection<Alumno> listaAlumnos;

        public ObservableCollection<Alumno> ListaAlumnos
        {
            get { return listaAlumnos; }
            set { SetProperty(ref listaAlumnos, value); }
        }

        private Alumno alumnoSeleccionado;

        public Alumno AlumnoSeleccionado
        {
            get { return alumnoSeleccionado; }
            set { SetProperty(ref alumnoSeleccionado, value); }
        }

        private ServicioAPI servicioAPI;

        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }
            set { SetProperty(ref apellidos, value); }
        }

        public AlumnosVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaAlumnos = servicioAPI.GetAlumnos();
        }
    }
}
