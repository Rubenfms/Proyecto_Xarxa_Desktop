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
    class AsignarLoteVM : ObservableObject
    {
        private ObservableCollection<int> listaNias;

        public ObservableCollection<int> ListaNias
        {
            get { return listaNias; }
            set { SetProperty(ref listaNias, value); }
        }

        private int? niaSeleccionado;

        public int? NiaSeleccionado
        {
            get { return niaSeleccionado; }
            set { SetProperty(ref niaSeleccionado, value); }
        }

        private string buscador;

        public string Buscador
        {
            get { return buscador; }
            set { SetProperty(ref buscador, value); }
        }

        private Lote loteAActualizar;

        public Lote LoteAActualizar
        {
            get { return loteAActualizar; }
            set { SetProperty(ref loteAActualizar, value); }
        }

        // Comandos
        public RelayCommand ConfirmarNiaCommand { get; }

        // Api
        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        public AsignarLoteVM()
        {
            ListaNias = ServicioDatos.ObtenerNiasDisponibles();

            // Recibimos el lote seleccionado de la vista de todos los lotes
            LoteAActualizar = WeakReferenceMessenger.Default.Send<EditarLoteRequestMessage>();
        }

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
