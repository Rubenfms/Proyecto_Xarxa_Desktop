using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    class VerIncidenciasAlumnoVM : ObservableRecipient
    {
        private string textoIncidencias;

        public string TextoIncidencias
        {
            get { return textoIncidencias; }
            set { SetProperty(ref textoIncidencias, value); }
        }

        private Alumno alumnoSeleccionado;

        public Alumno AlumnoSeleccionado
        {
            get { return alumnoSeleccionado; }
            set { SetProperty(ref alumnoSeleccionado, value); }
        }

        // Comandos
        public RelayCommand GuardarIncidenciaCommand { get; }

        // Api
        ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        public VerIncidenciasAlumnoVM()
        {
            // Recibimos el alumno del que queremos ver las incidencias
            AlumnoSeleccionado = WeakReferenceMessenger.Default.Send<IncidenciasRequestMessage>();

            // Asignamos las incidencias del alumno a nuestra entrada de texto
            TextoIncidencias = AlumnoSeleccionado.Incidencias;

            // Comando
            GuardarIncidenciaCommand = new RelayCommand(GuardarIncidencia);
        }

        public void GuardarIncidencia()
        {
            AlumnoSeleccionado.Incidencias = TextoIncidencias;
            HttpStatusCode? statusCode = servicioAPI.PutAlumno(AlumnoSeleccionado);
            ServicioDialogos.ServicioMessageBox($"Resultado de la actualización de incidencias: {statusCode}", "Resultado operación", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
