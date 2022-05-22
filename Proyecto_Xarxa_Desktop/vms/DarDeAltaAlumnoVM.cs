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
    /// VM de DarDeAltaDialog.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class DarDeAltaAlumnoVM : ObservableObject
    {
        /// <summary>
        /// The nia introducido
        /// </summary>
        private string niaIntroducido;

        /// <summary>
        /// Gets or sets the nia introducido.
        /// </summary>
        /// <value>
        /// The nia introducido.
        /// </value>
        public string NiaIntroducido
        {
            get { return niaIntroducido; }
            set { SetProperty(ref niaIntroducido, value); }
        }

        /// <summary>
        /// The nombre introducido
        /// </summary>
        private string nombreIntroducido;

        /// <summary>
        /// Gets or sets the nombre introducido.
        /// </summary>
        /// <value>
        /// The nombre introducido.
        /// </value>
        public string NombreIntroducido
        {
            get { return nombreIntroducido; }
            set { SetProperty(ref nombreIntroducido, value); }
        }

        /// <summary>
        /// The primer apellido introducido
        /// </summary>
        private string primerApellidoIntroducido;

        /// <summary>
        /// Gets or sets the primer apellido introducido.
        /// </summary>
        /// <value>
        /// The primer apellido introducido.
        /// </value>
        public string PrimerApellidoIntroducido
        {
            get { return primerApellidoIntroducido; }
            set { SetProperty(ref primerApellidoIntroducido, value); }
        }

        /// <summary>
        /// The segundo apellido introducido
        /// </summary>
        private string segundoApellidoIntroducido;

        /// <summary>
        /// Gets or sets the segundo apellido introducido.
        /// </summary>
        /// <value>
        /// The segundo apellido introducido.
        /// </value>
        public string SegundoApellidoIntroducido
        {
            get { return segundoApellidoIntroducido; }
            set { SetProperty(ref segundoApellidoIntroducido, value); }
        }

        /// <summary>
        /// Alumno encontrado a partir de los datos introducidos.
        /// </summary>
        private Alumno alumnoEncontrado;

        /// <summary>
        /// Gets or sets the alumno encontrado.
        /// </summary>
        /// <value>
        /// The alumno encontrado.
        /// </value>
        public Alumno AlumnoEncontrado
        {
            get { return alumnoEncontrado; }
            set { SetProperty(ref alumnoEncontrado, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private ServicioAPI servicioAPI;

        /// <summary>
        /// Initializes a new instance of the <see cref="DarDeAltaAlumnoVM"/> class.
        /// </summary>
        public DarDeAltaAlumnoVM()
        {
            // Api
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        }

        /// <summary>
        /// Método que se ejecuta cuando pulsas el botón de buscar en la pantalla de buscar por nombre y apellidos.
        /// </summary>
        /// <returns>Devuelve booleano, dependiendo de si se ha encontrado el alumno o no, de si se han rellenado todos los campos o no o de si el alumno está ya dado de alta o no.</returns>
        public bool BuscarPorNombre()
        {
            try
            {
                if (NombreIntroducido.Length <= 0 || PrimerApellidoIntroducido.Length <= 0 || SegundoApellidoIntroducido.Length <= 0)
                {
                    ServicioDialogos.ServicioMessageBox("Rellena todos los campos para buscar el alumno", "Campos no rellenos", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return false;
                }
                else
                {
                    // Obtenemos el alumno con los datos introducidos
                    int? niaAlumnoEncontrado = ServicioSQL.GetAlumnoByNombreYApellidos(NombreIntroducido, PrimerApellidoIntroducido, SegundoApellidoIntroducido);
                    // Si no existe mostramos error
                    if (niaAlumnoEncontrado == null)
                    {
                        ServicioDialogos.ServicioMessageBox("No se ha encontrado ningun alumno con esos datos", "Alumno no encontrado", MessageBoxButton.OK, MessageBoxImage.Information);
                        return false;
                    }
                    // Si existe lo damos de alta
                    else
                    {
                        Alumno alumnoEncontrado = servicioAPI.GetAlumno((int)niaAlumnoEncontrado);
                        if (alumnoEncontrado.PerteneceXarxa)
                        {
                            ServicioDialogos.ServicioMessageBox($"El alumno ya está dado de alta en la Xarxa", "Alumno ya dado de alta", MessageBoxButton.OK, MessageBoxImage.Information);
                            return false;
                        }
                        else
                        {
                            alumnoEncontrado.PerteneceXarxa = true;
                            HttpStatusCode? statusCode = servicioAPI.PutAlumno(alumnoEncontrado);
                            ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                            WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.OK));
                            return true;
                        }
                    }
                }
            }
            catch(NullReferenceException)
            {
                ServicioDialogos.ServicioMessageBox("Rellena todos los campos para buscar el alumno", "Campos no rellenos", MessageBoxButton.OK, MessageBoxImage.Hand);
                return false;
            }
        }

        /// <summary>
        ///  Método que se ejecuta cuando pulsas el botón de buscar en la pantalla de buscar por NIA.
        /// </summary>
        /// <returns>Devuelve booleano, dependiendo de si se ha encontrado el alumno o no, de si se han rellenado todos los campos o no o de si el alumno está ya dado de alta o no.</returns>
        public bool BuscarPorNia()
        {
            if (Int32.TryParse(NiaIntroducido, out _))
            {
                Alumno aEncontrado = servicioAPI.GetAlumno(Int32.Parse(NiaIntroducido));
                if (aEncontrado == null)
                {
                    ServicioDialogos.ServicioMessageBox("No hay un alumno con ese NIA registrado", "NIA no encontrado", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (aEncontrado.PerteneceXarxa)
                {
                    ServicioDialogos.ServicioMessageBox($"El alumno ya está dado de alta en la Xarxa", "Alumno ya dado de alta", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else
                {
                    aEncontrado.PerteneceXarxa = true;
                    HttpStatusCode? statusCode = servicioAPI.PutAlumno(aEncontrado);
                    ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                    WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.OK));
                    return true;
                }
            }
            else
            {
                ServicioDialogos.ServicioMessageBox("El formato de NIA introducido no es válido. Prueba a introducir solo números.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}