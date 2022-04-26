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
        public LotesVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaLotes = servicioAPI.GetLotes();
            LoteSeleccionado = new Lote();
        }

        public void AbrirVistaGenerarLote()
        {
            ServicioNavegacion.AbrirVistaGenerarLote();
        }
    }
}
