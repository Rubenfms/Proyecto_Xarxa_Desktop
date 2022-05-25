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
    /// VM de EditarAlumnoDialog
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class EditarAlumnoVM : ObservableObject
    {
        /// <summary>
        /// El alumno que está siendo editado.
        /// </summary>
        private Alumno alumno;
        /// <summary>
        /// Gets or sets el alumno que está siendo editado.
        /// </summary>
        /// <value>
        /// El alumno que está siendo editado.
        /// </value>
        public Alumno Alumno
        {
            get => alumno;
            set => SetProperty(ref alumno, value);
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="EditarAlumnoVM"/> class.
        /// </summary>
        public EditarAlumnoVM()
        {
            RecibirAlumno();
            EditarAlumnoCommand = new RelayCommand(EditarAlumno);
        }

        /// <summary>
        /// Gets the editar alumno command.
        /// </summary>
        /// <value>
        /// The editar alumno command.
        /// </value>
        public RelayCommand EditarAlumnoCommand { get; }

        /// <summary>
        /// Recibirs the alumno.
        /// </summary>
        public void RecibirAlumno()
        {
            Alumno = WeakReferenceMessenger.Default.Send<AlumnoSeleccionadoRequestMessage>();
            Alumno = new Alumno(Alumno);
        }

        /// <summary>
        /// Edita el alumno the alumno.
        /// </summary>
        public void EditarAlumno()
        {
            if (ComprobarDatosIntroducidos())
            {
                HttpStatusCode? statusCode = servicioAPI.PutAlumno(Alumno);
                ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.OK));
            }
        }

        /// <summary>
        /// Comprueba los datos introducidos en el formulario.
        /// </summary>
        /// <returns>Devuelve true o false dependiendo de si los datos introducidos son correctos</returns>
        public bool ComprobarDatosIntroducidos()
        {
            try
            {
                if (Alumno.Grupo == null || Alumno.Grupo.Length == 0)
                {
                    ServicioDialogos.ServicioMessageBox("Introduce un grupo.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else if (Alumno.Curso == null || Alumno.Curso.Length == 0)
                {
                    ServicioDialogos.ServicioMessageBox("Introduce un curso.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }
}
