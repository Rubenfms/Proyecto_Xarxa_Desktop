using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    class DarDeAltaAlumnoVM : ObservableObject
    {
        private string datoABuscar;

        public string DatoABuscar
        {
            get { return datoABuscar; }
            set { SetProperty(ref datoABuscar, value); }
        }

        private Alumno alumnoEncontrado;

        public Alumno AlumnoEncontrado
        {
            get { return alumnoEncontrado; }
            set { SetProperty(ref alumnoEncontrado, value); }
        }

        public RelayCommand BuscarAlumnoCommand { get; }

        private ServicioAPI servicioAPI;
        public DarDeAltaAlumnoVM()
        {
            // Api
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

            // Comandos
            BuscarAlumnoCommand = new RelayCommand(BuscarAlumno);

        }

        public void BuscarAlumno()
        {
            int nia;
            if(Int32.TryParse(DatoABuscar, out nia))
            {
                // Buscamos por NIA
                AlumnoEncontrado = servicioAPI.GetAlumno(nia);
                if(AlumnoEncontrado == null)
                {
                    ServicioDialogos.ServicioMessageBox($"Alumno con NIA: {nia} no encontrado", "Alumno no encontrado", MessageBoxButton.OK, MessageBoxImage.Error);
                    DatoABuscar = null;
                }
            }
            else
            {
                // TODO: Buscar por nombre
            }
        }
    }
}
