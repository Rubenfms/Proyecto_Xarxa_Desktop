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
    class EditarAlumnoVM : ObservableObject
    {
        private Alumno alumno;
        public Alumno Alumno
        {
            get => alumno;
            set => SetProperty(ref alumno, value);
        }

        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        public EditarAlumnoVM()
        {
            RecibirAlumno();
            EditarAlumnoCommand = new RelayCommand(EditarAlumno);
        }

        public RelayCommand EditarAlumnoCommand { get; }

        public void RecibirAlumno()
        {
            Alumno = WeakReferenceMessenger.Default.Send<AlumnoSeleccionadoRequestMessage>();
            Alumno = new Alumno(Alumno);
        }


        public void EditarAlumno()
        {
            if (ComprobarDatosIntroducidos())
            {
                HttpStatusCode? statusCode = servicioAPI.PutAlumno(Alumno);
                ServicioDialogos.ServicioMessageBox($"Resultado del alta del alumno: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.OK));
            }
        }

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
