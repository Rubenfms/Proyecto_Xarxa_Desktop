using Microsoft.Toolkit.Mvvm.ComponentModel;
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
        public GenerarLoteVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaModalidades = servicioAPI.GetModalidades();
        }

        public void CargarModalidades(string modalidadSeleccionada)
        {
            foreach(Modalidad m in ListaModalidades)
            {
                if(m.Nombre.Equals(modalidadSeleccionada))
                {
                    ModalidadSeleccionada = m;
                }
            }
        }

        public string GenerarNumeroLote(Modalidad modalidadSeleccionada)
        {
            string curso = modalidadSeleccionada.Curso.Remove(1, modalidadSeleccionada.Curso.Length - 1); // Como viene en formato (1ºESO) me quedo solo con el numero
            return $"{curso}{modalidadSeleccionada.Id}000";
        }
    }
}
