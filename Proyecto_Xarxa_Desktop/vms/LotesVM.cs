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
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class LotesVM : ObservableObject
    {
        private ObservableCollection<Lote> listaLotes;

        public ObservableCollection<Lote> ListaLotes
        {
            get { return listaLotes; }
            set { SetProperty(ref listaLotes, value); }
        }

        private Lote loteSeleccionado;

        public Lote LoteSeleccionado
        {
            get { return loteSeleccionado; }
            set { SetProperty(ref loteSeleccionado, value); }
        }

        private ServicioAPI servicioAPI;

        // Comandos
        public RelayCommand GenerarLoteCommand { get; }
        public RelayCommand EliminarLoteCommand { get; }
        public RelayCommand EditarLoteCommand { get; }
        public RelayCommand AsignarLoteCommand { get; }
        public RelayCommand DesasignarLoteCommand { get; }

        public LotesVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaLotes = servicioAPI.GetLotes();
            LoteSeleccionado = new Lote();

            // Comandos
            GenerarLoteCommand = new RelayCommand(AbrirVistaGenerarLote);
            AsignarLoteCommand = new RelayCommand(AsignarLote);
            DesasignarLoteCommand = new RelayCommand(DesasignarLote);
            EditarLoteCommand = new RelayCommand(EditarLote);
            EliminarLoteCommand = new RelayCommand(EliminarLote);

            // Suscripción para mandar el lote en editar
            WeakReferenceMessenger.Default.Register<LotesVM, LoteRequestMessage>
                (this, (r, m) =>
                {
                    m.Reply(LoteSeleccionado);
                });
        }

        public void AbrirVistaGenerarLote()
        {
            ServicioNavegacion.AbrirVistaGenerarLote();
        }

        public void AsignarLote()
        {
            // Comprobación de si hay lote seleccionado
            if (LoteSeleccionado == null)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un lote para poder asignarlo", "Necesario Lote Seleccionado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            // Comprobación de que el lote seleccionado no tenga nia asignado
            else if (LoteSeleccionado.NiaAlumno != 0)
            {
                ServicioDialogos.ServicioMessageBox($"El lote ya tiene un nia asignado: {LoteSeleccionado.NiaAlumno}", "Lote ya asignado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            else
            {
                
            }

        }
        public void DesasignarLote()
        {
            // Comprobación de si hay lote seleccionado
            if (LoteSeleccionado == null)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un lote para poder asignarlo", "Necesario Lote Seleccionado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            // Comprobación de que el lote no tenga ningun nia asignado
            else if (LoteSeleccionado.NiaAlumno > 0)
            {
                ServicioDialogos.ServicioMessageBox("El lote no tiene ningún nia asignado", "Nia no asignado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            else
            {
                //LoteSeleccionado.NiaAlumno = null;
            }
        }
        public void EditarLote()
        {
            ServicioNavegacion.AbrirVistaEditarLote();
        }
        public void EliminarLote()
        {

        }
    }
}
