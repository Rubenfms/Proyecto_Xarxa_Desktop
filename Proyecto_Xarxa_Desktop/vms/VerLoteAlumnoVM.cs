using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class VerLoteAlumnoVM : ObservableRecipient
    {
        private Alumno alumno;

        public Alumno Alumno
        {
            get { return alumno; }
            set { SetProperty(ref alumno, value); }
        }

        private Lote loteAlumno;

        public Lote LoteAlumno
        {
            get { return loteAlumno; }
            set { SetProperty(ref loteAlumno, value); }
        }

        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        public VerLoteAlumnoVM()
        {
            // Recibimos el alumno seleccionado de la vista de todos los alumnos
            Alumno = WeakReferenceMessenger.Default.Send<AlumnoRequestMessage>();

            LoteAlumno = servicioAPI.GetLote(Alumno.Lote.IdLote);
        }
    }
}
