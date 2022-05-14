using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM para la vista de AsignarLoteDialog.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class AsignarLoteVM : ObservableObject
    {
        /// <summary>
        /// Lista de NIAs
        /// </summary>
        private ObservableCollection<int> listaNias;

        /// <summary>
        /// Gets or sets the lista NIAs.
        /// </summary>
        /// <value>
        /// Lista de NIAs
        /// </value>
        public ObservableCollection<int> ListaNias
        {
            get { return listaNias; }
            set { SetProperty(ref listaNias, value); }
        }

        /// <summary>
        /// NIA seleccionado en la lista
        /// </summary>
        private int? niaSeleccionado;

        /// <summary>
        /// Gets or sets the nia seleccionado.
        /// </summary>
        /// <value>
        /// NIA seleccionado en la lista
        /// </value>
        public int? NiaSeleccionado
        {
            get { return niaSeleccionado; }
            set { SetProperty(ref niaSeleccionado, value); }
        }

        /// <summary>
        /// Lote que vamos a actualizar (lo recibimos de la vista de Lotes)
        /// </summary>
        private Lote loteAActualizar;

        /// <summary>
        /// Gets or sets the lote a actualizar.
        /// </summary>
        /// <value>
        ///  Lote que vamos a actualizar
        /// </value>
        public Lote LoteAActualizar
        {
            get { return loteAActualizar; }
            set { SetProperty(ref loteAActualizar, value); }
        }

        /// <summary>
        /// Gets the confirmar nia command.
        /// </summary>
        /// <value>
        /// The confirmar nia command.
        /// </value>
        public RelayCommand ConfirmarNiaCommand { get; }

        /// <summary>
        /// The servicio API
        /// </summary>
        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="AsignarLoteVM"/> class.
        /// </summary>
        public AsignarLoteVM()
        {
            ListaNias = ServicioDatos.ObtenerNiasDisponibles();

            // Recibimos el lote seleccionado de la vista de todos los lotes
            LoteAActualizar = WeakReferenceMessenger.Default.Send<AsignarLoteRequestMessage>();
        }

        /// <summary>
        /// Método que actualiza el lote recibido añadiéndole el NIA que queremos asignar y devuelve bool
        /// </summary>
        /// <returns>bool dependiendo de si se ha asignado correctamente o el usuario no ha asignado ningún NIA</returns>
        public bool? ConfirmarNia()
        {
            if (NiaSeleccionado != null)
            {
                LoteAActualizar.NiaAlumno = NiaSeleccionado;
                HttpStatusCode? statusCode = servicioAPI.PutLote(LoteAActualizar);
                ServicioDialogos.ServicioMessageBox($"Resultado de la asignación del NIA {NiaSeleccionado} al lote: {statusCode}", "Asignación NIA", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return true;
            }
            else
            {
                ServicioDialogos.ServicioMessageBox("Tienes que seleccionar un NIA", "Selecciona un NIA", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return false;
            }


        }

    }
}
