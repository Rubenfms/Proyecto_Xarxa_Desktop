using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class EditarLoteVM : ObservableRecipient
    {
        private Lote lote;

        public Lote Lote
        {
            get { return lote; }
            set { SetProperty(ref lote, value); }
        }

        public EditarLoteVM()
        {
            // Recibimos el lote seleccionado de la vista de todos los lotes
            Lote = WeakReferenceMessenger.Default.Send<EditarLoteRequestMessage>();
        }
    }
}
