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
    /// <summary>
    /// VM de VerIncidenciasAlumno.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableRecipient" />
    class VerIncidenciasAlumnoVM : ObservableRecipient
    {
        /// <summary>
        /// The texto incidencias
        /// </summary>
        private string textoIncidencias;

        /// <summary>
        /// Gets or sets the texto incidencias.
        /// </summary>
        /// <value>
        /// The texto incidencias.
        /// </value>
        public string TextoIncidencias
        {
            get { return textoIncidencias; }
            set { SetProperty(ref textoIncidencias, value); }
        }

        /// <summary>
        /// Alumno seleccionado de la lista de AlumnosVM
        /// </summary>
        private Alumno alumnoSeleccionado;

        /// <summary>
        /// Gets or sets the alumno seleccionado.
        /// </summary>
        /// <value>
        /// Alumno seleccionado de la lista de AlumnosVM
        /// </value>
        public Alumno AlumnoSeleccionado
        {
            get { return alumnoSeleccionado; }
            set { SetProperty(ref alumnoSeleccionado, value); }
        }

        // Comandos        
        /// <summary>
        /// Gets the guardar incidencia command.
        /// </summary>
        /// <value>
        /// The guardar incidencia command.
        /// </value>
        public RelayCommand GuardarIncidenciaCommand { get; }

        // Api        
        /// <summary>
        /// The servicio API
        /// </summary>
        readonly ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="VerIncidenciasAlumnoVM"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor will produce an instance that will use the <see cref="P:Microsoft.Toolkit.Mvvm.Messaging.WeakReferenceMessenger.Default" /> instance
        /// to perform requested operations. It will also be available locally through the <see cref="P:Microsoft.Toolkit.Mvvm.ComponentModel.ObservableRecipient.Messenger" /> property.
        /// </remarks>
        public VerIncidenciasAlumnoVM()
        {
            // Recibimos el alumno del que queremos ver las incidencias
            AlumnoSeleccionado = WeakReferenceMessenger.Default.Send<AlumnoSeleccionadoRequestMessage>();

            // Asignamos las incidencias del alumno a nuestra entrada de texto
            TextoIncidencias = AlumnoSeleccionado.Incidencias;

            // Comando
            GuardarIncidenciaCommand = new RelayCommand(GuardarIncidencia);
        }

        /// <summary>
        /// Guarda la incidencia introducida en el textbox.
        /// </summary>
        public void GuardarIncidencia()
        {
            AlumnoSeleccionado.Incidencias = TextoIncidencias;
            HttpStatusCode? statusCode = servicioAPI.PutAlumno(AlumnoSeleccionado);
            ServicioDialogos.ServicioMessageBox($"Resultado de la actualización de incidencias: {statusCode}", "Resultado operación", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
