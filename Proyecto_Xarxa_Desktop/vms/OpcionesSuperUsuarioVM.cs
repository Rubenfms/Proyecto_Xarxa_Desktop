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
    /// <summary>
    /// VM de OpcionesSuperUsuario.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class OpcionesSuperUsuarioVM : ObservableObject
    {
        // Comandos        
        /// <summary>
        /// Gets the abrir vista usuario command.
        /// </summary>
        /// <value>
        /// The abrir vista usuario command.
        /// </value>
        public RelayCommand AbrirVistaUsuarioCommand { get; }

        /// <summary>
        /// Gets the carga inicial CSV command.
        /// </summary>
        /// <value>
        /// The carga inicial CSV command.
        /// </value>
        public RelayCommand CargaInicialCSVCommand { get; }

        /// <summary>
        /// Gets the abrir vista administrar usuarios command.
        /// </summary>
        /// <value>
        /// The abrir vista administrar usuarios command.
        /// </value>
        public RelayCommand AbrirVistaAdministrarUsuariosCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcionesSuperUsuarioVM"/> class.
        /// </summary>
        public OpcionesSuperUsuarioVM()
        {
            AbrirVistaUsuarioCommand = new RelayCommand(AbrirVistaNuevoUsuario);
            CargaInicialCSVCommand = new RelayCommand(CargaInicialCSV);
            AbrirVistaAdministrarUsuariosCommand = new RelayCommand(AbrirVistaAdministrarUsuarios);

        }

        /// <summary>
        /// Abre la vista de nuevo usuario.
        /// </summary>
        public void AbrirVistaNuevoUsuario() => ServicioNavegacion.AbrirVistaNuevoUsuario();

        /// <summary>
        /// Abre un dialogo para seleccionar archivos
        /// </summary>
        public void CargaInicialCSV() => ServicioDialogos.OpenFileDialogService();

        /// <summary>
        /// Abre la vista administrar usuarios.
        /// </summary>
        public void AbrirVistaAdministrarUsuarios() => ServicioNavegacion.AbrirVistaAdministrarUsuarios();

    }
}
