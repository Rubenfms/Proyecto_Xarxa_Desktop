using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.modelo;
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
        private Usuario usuarioLogeado;

        public Usuario UsuarioLogeado
        {
            get { return usuarioLogeado; }
            set { SetProperty(ref usuarioLogeado, value); }
        }

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
            UsuarioLogeado = ServicioValidarUsuario.UsuarioActual;
        }

        public void AbrirVistaLotes() => PestanyaActual = ServicioNavegacion.AbrirVistaLotes();

        public void AbrirVistaAlumnos() => PestanyaActual = ServicioNavegacion.AbrirVistaAlumnos();

        public void AbrirOpcionesSU() =>  ServicioNavegacion.AbrirVistaOpcionesSU();

        public void CerrarSesion()
        {
            ServicioNavegacion.AbrirVistaLogIn();
            UsuarioLogeado = new Usuario();
        }
    }
}
