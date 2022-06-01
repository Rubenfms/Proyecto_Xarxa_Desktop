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
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    class BorrarModalidadVM : ObservableObject
    {
        private ObservableCollection<Modalidad> listaModalidades;

        public ObservableCollection<Modalidad> ListaModalidades
        {
            get { return listaModalidades; }
            set { SetProperty(ref listaModalidades, value); }
        }

        private Modalidad modalidadSeleccionada;

        public Modalidad ModalidadSeleccionada
        {
            get { return modalidadSeleccionada; }
            set { SetProperty(ref modalidadSeleccionada, value); }
        }

        private ServicioAPI servicioAPI;
        public RelayCommand BorrarCommand { get; }

        private ObservableCollection<Lote> listaLotes;

        public BorrarModalidadVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaModalidades = servicioAPI.GetModalidades();
            BorrarCommand = new RelayCommand(BorrarModalidad);
        }

        public void CargarModalidades(string modalidadSeleccionada)
        {
            foreach (Modalidad m in ListaModalidades)
            {
                if (m.Nombre.Equals(modalidadSeleccionada))
                {
                    ModalidadSeleccionada = m;
                }
            }
        }

        public void BorrarModalidad()
        {
            MessageBoxResult result = ServicioDialogos.ServicioMessageBoxResult("Al eliminar esta modalidad se eliminarán también todos los lotes de esta modalidad. ¿Desea proceder?", "Cuidado", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                listaLotes = servicioAPI.GetLotes();
                foreach(Lote item in listaLotes)
                {
                    if(item.ModalidadLote.Id == ModalidadSeleccionada.Id)
                    {
                        servicioAPI.DeleteLote(item.IdLote);
                    }
                }

                HttpStatusCode? statusCode = servicioAPI.DeleteModalidad(ModalidadSeleccionada.Id);

                WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(statusCode == HttpStatusCode.OK));

                ServicioDialogos.ServicioMessageBox($"Resultado de la eliminacion de la modalidad: {statusCode}", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);


            }
        }
    }
}
