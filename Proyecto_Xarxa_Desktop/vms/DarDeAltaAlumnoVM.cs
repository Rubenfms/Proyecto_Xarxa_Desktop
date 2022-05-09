using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
    class DarDeAltaAlumnoVM : ObservableObject
    {
        private string niaIntroducido;

        public string NiaIntroducido
        {
            get { return niaIntroducido; }
            set { SetProperty(ref niaIntroducido, value); }
        }

        private string nombreIntroducido;

        public string NombreIntroducido
        {
            get { return nombreIntroducido; }
            set { SetProperty(ref nombreIntroducido, value); }
        }

        private string primerApellidoIntroducido;

        public string PrimerApellidoIntroducido
        {
            get { return primerApellidoIntroducido; }
            set { SetProperty(ref primerApellidoIntroducido, value); }
        }

        private string segundoApellidoIntroducido;

        public string SegundoApellidoIntroducido
        {
            get { return segundoApellidoIntroducido; }
            set { SetProperty(ref segundoApellidoIntroducido, value); }
        }

        private Alumno alumnoEncontrado;

        public Alumno AlumnoEncontrado
        {
            get { return alumnoEncontrado; }
            set { SetProperty(ref alumnoEncontrado, value); }
        }

        private ServicioAPI servicioAPI;
        public DarDeAltaAlumnoVM()
        {
            // Api
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        }

        // Método que se ejecuta cuando pulsas el botón de buscar en la pantalla de buscar por nombre y apellidos
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
                            ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Alta correcta", MessageBoxButton.OK, MessageBoxImage.Information);
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
        // Método que se ejecuta cuando pulsas el botón de buscar en la pantalla de buscar por NIA
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
                    ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Alta correcta", MessageBoxButton.OK, MessageBoxImage.Information);
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