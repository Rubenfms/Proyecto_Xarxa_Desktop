using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
        // Comandos
        public RelayCommand AbrirVistaUsuarioCommand { get; }
        public RelayCommand CargaInicialCSVCommand { get; }

        public OpcionesSuperUsuarioVM()
        {
            AbrirVistaUsuarioCommand = new RelayCommand(AbrirVistaNuevoUsuario);
            CargaInicialCSVCommand = new RelayCommand(CargaInicialCSV);
        }

        public void AbrirVistaNuevoUsuario() => ServicioNavegacion.AbrirVistaNuevoUsuario();
        public void CargaInicialCSV() => ServicioDialogos.OpenFileDialogService();

    }
}
