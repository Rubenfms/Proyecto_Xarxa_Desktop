using Microsoft.Toolkit.Mvvm.ComponentModel;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proyecto_Xarxa_Desktop.vms
{
    class MainWindowVM : ObservableObject
    {
        private UserControl pestanyaActual;

        public UserControl PestanyaActual
        {
            get { return pestanyaActual; }
            set { SetProperty(ref pestanyaActual, value); }
        }

        public MainWindowVM()
        {
            // Instancia vacía para que al iniciar el programa no aparezca ningún UserControl seleccionado
            PestanyaActual = new UserControl();
        }

        public void AbrirVistaLotes() => PestanyaActual = ServicioNavegacion.AbrirVistaLotes();
        
    }
}
