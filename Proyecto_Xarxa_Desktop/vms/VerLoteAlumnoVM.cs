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
    /// <summary>
    /// VM de VerLoteAlumno.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableRecipient" />
    class VerLoteAlumnoVM : ObservableRecipient
    {
        /// <summary>
        /// Alumno al que pertenece el lote
        /// </summary>
        private Alumno alumno;

        /// <summary>
        /// Gets or sets the alumno.
        /// </summary>
        /// <value>
        /// Alumno al que pertenece el lote
        /// </value>
        public Alumno Alumno
        {
            get { return alumno; }
            set { SetProperty(ref alumno, value); }
        }

        /// <summary>
        /// Lote que pertenece al alumno.
        /// </summary>
        private Lote loteAlumno;

        /// <summary>
        /// Gets or sets the lote alumno.
        /// </summary>
        /// <value>
        /// Lote que pertenece al alumno.
        /// </value>
        public Lote LoteAlumno
        {
            get { return loteAlumno; }
            set { SetProperty(ref loteAlumno, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="VerLoteAlumnoVM"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor will produce an instance that will use the <see cref="P:Microsoft.Toolkit.Mvvm.Messaging.WeakReferenceMessenger.Default" /> instance
        /// to perform requested operations. It will also be available locally through the <see cref="P:Microsoft.Toolkit.Mvvm.ComponentModel.ObservableRecipient.Messenger" /> property.
        /// </remarks>
        public VerLoteAlumnoVM()
        {
            try
            {
                // Recibimos el alumno seleccionado de la vista de todos los alumnos
                LoteAlumno = WeakReferenceMessenger.Default.Send<VerLoteRequestMessage>();
            }
            catch (InvalidOperationException)
            {
                LoteAlumno = null;
            }
        }
    }
}
