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
    class AnyadirAlumnoVM : ObservableObject
    {
        private string nia;

        public string Nia
        {
            get { return nia; }
            set { SetProperty(ref nia, value); }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string apellido1;

        public string Apellido1
        {
            get { return apellido1; }
            set { SetProperty(ref apellido1, value); }
        }

        private string apellido2;

        public string Apellido2
        {
            get { return apellido2; }
            set { SetProperty(ref apellido2, value); }
        }

        private string matricula;

        public string Matricula
        {
            get { return matricula; }
            set { SetProperty(ref matricula, value); }
        }

        private string curso;

        public string Curso
        {
            get { return curso; }
            set { SetProperty(ref curso, value); }
        }

        private bool xarxa;

        public bool Xarxa
        {
            get { return xarxa; }
            set { SetProperty(ref xarxa, value); }
        }

        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        public AnyadirAlumnoVM()
        {

        }

        public bool AnyadirUsuario()
        {
            if (ComprobarDatosIntroducidos())
            {
                HttpStatusCode? statusCode = servicioAPI.PostAlumno(new Alumno(Int32.Parse(Nia), Nombre, Apellido1, Apellido2, Matricula, Curso, Curso, "", Xarxa));
                ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.Created));
                return true;
            }
            else return false;
        }

        public bool ComprobarDatosIntroducidos()
        {
            if (!Int32.TryParse(Nia, out _))
            {
                ServicioDialogos.ServicioMessageBox("El formato de NIA introducido no es válido. Prueba a introducir solo números.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Nombre.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce un nombre.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Apellido1.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce un primer apellido.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Apellido2.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce un segundo apellido.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Matricula.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce un estado de matriculación.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Curso.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce un curso.", "Formato no válido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}