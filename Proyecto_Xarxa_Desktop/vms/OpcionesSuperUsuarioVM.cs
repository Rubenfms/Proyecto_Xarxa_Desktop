using Microsoft.Toolkit.Mvvm.ComponentModel;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class OpcionesSuperUsuarioVM : ObservableObject
    {
        public OpcionesSuperUsuarioVM()
        {

        }

        public void AbrirVistaNuevoUsuario() => ServicioNavegacion.AbrirVistaNuevoUsuario();
    }
}
