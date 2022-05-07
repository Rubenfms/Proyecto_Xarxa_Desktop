using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
    class GenerarLoteVM : ObservableObject
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

        private int? idLote;

        public int? IdLote
        {
            get { return idLote; }
            set { SetProperty(ref idLote, value); }
        }

        public RelayCommand ConfirmarLoteCommand { get; }
        public RelayCommand LimpiarSeleccionCommand { get; }

        public GenerarLoteVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaModalidades = servicioAPI.GetModalidades();

            // Comandos
            LimpiarSeleccionCommand = new RelayCommand(LimpiarIdLote);
            ConfirmarLoteCommand = new RelayCommand(ConfirmarLote);
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

        public void GenerarNumeroLote(Modalidad modalidadSeleccionada)
        {
            string curso = ModalidadSeleccionada.Curso.Remove(1, ModalidadSeleccionada.Curso.Length - 1); // Como viene en formato (1ºESO) me quedo solo con el numero

            // Hallamos el idLote
            IdLote = ServicioSQL.HallarUltLote(Int32.Parse(curso), modalidadSeleccionada.Id);

        }

        public void LimpiarIdLote()
        {
            ModalidadSeleccionada = null;
            IdLote = null;
        }

        public void ConfirmarLote()
        {
            //Lote nuevolote = new Lote((int)IdLote, modalidadSeleccionada.LibrosModalidad, ModalidadSeleccionada);
        }
    }
}
