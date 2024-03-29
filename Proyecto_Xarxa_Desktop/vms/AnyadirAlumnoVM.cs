using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    /// VM de AnyadirAlumnoDialog
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class AnyadirAlumnoVM : ObservableObject
    {

        /// <summary>
        /// El alumno a añadir
        /// </summary>
        private Alumno alumno;

        /// <summary>
        /// Gets or sets el alumno a añadir.
        /// </summary>
        /// <value>
        /// El alumno a añadir
        /// </value>
        public Alumno Alumno
        {
            get => alumno;
            set => SetProperty(ref alumno, value);
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private readonly ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyadirAlumnoVM"/> class.
        /// </summary>
        public AnyadirAlumnoVM()
        {
            Alumno = new Alumno();
        }

        /// <summary>
        /// Añade un nuevo alumno.
        /// </summary>
        /// <returns>Devuelve true o false dependiendo de si el alumno ha sido añadido.</returns>
        public bool AnyadirAlumno()
        {
            if (ComprobarDatosIntroducidos())
            {
                HttpStatusCode? statusCode = servicioAPI.PostAlumno(Alumno);
                ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.Created));
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Comprueba los datos introducidos en el formulario de añadir alumno.
        /// </summary>
        /// <returns>Devuelve true o false dependiendo de si todos los campos introducido son correctos.</returns>
        public bool ComprobarDatosIntroducidos()
        {
            try
            {
                if (Alumno.Nia == 0 || Alumno.Nia.ToString().Length != 8)
                {
                    ServicioDialogos.ServicioMessageBox("El formato de NIA introducido no es válido (Ej:10099888). Prueba a introducir solo números.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else if (Alumno.Nombre == null || Alumno.Nombre.Length == 0)
                {
                    ServicioDialogos.ServicioMessageBox("Introduce un nombre.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else if (Alumno.Apellido1 == null || Alumno.Apellido1.Length == 0)
                {
                    ServicioDialogos.ServicioMessageBox("Introduce un primer apellido.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else if (Alumno.Apellido2 == null || Alumno.Apellido2.Length == 0)
                {
                    ServicioDialogos.ServicioMessageBox("Introduce un segundo apellido.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else if (Alumno.Matricula == null || Alumno.Matricula.Length == 0)
                {
                    ServicioDialogos.ServicioMessageBox("Introduce un estado de matriculación.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
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
