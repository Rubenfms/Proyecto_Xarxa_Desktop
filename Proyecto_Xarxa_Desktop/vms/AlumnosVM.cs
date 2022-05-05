using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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

        private string buscador;

        public string Buscador
        {
            get { return buscador; }
            set { SetProperty(ref buscador, value); }
        }

        // Comandos
        public RelayCommand DarDeAltaCommand { get; }

        public RelayCommand VerLoteUsuarioCommand { get; }

        public AlumnosVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            //ListaAlumnos = servicioAPI.GetAlumnos();
            ListaAlumnos = ServicioCsv.GetListaAlumnosFromCSV();
            // Comandos
            DarDeAltaCommand = new RelayCommand(DarDeAlta);
            VerLoteUsuarioCommand = new RelayCommand(VerLoteUsuario);

        }

        public void DarDeAlta()
        {
            ServicioNavegacion.AbrirVistaDarDeAlta();
        }

        public void VerLoteUsuario()
        {
            ServicioDialogos.ServicioMessageBox(AlumnoSeleccionado.Lote.ToString(), "TO DO:", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}
