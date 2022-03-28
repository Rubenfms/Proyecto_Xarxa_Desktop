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
    class LogInVM : ObservableObject
    {
        private ObservableCollection<Usuario> listaUsuarios;

        public ObservableCollection<Usuario> ListaUsuarios
        {
            get { return listaUsuarios; }
            set { SetProperty(ref listaUsuarios, value); }
        }
        private Usuario usuarioXarxa;

        public Usuario UsuarioXarxa
        {
            get { return usuarioXarxa; }
            set { SetProperty(ref usuarioXarxa, value); }
        }

        public LogInVM()
        {
            UsuarioXarxa = new Usuario();
            listaUsuarios = ServicioAPI.GetUsuarios();
        }

        public bool ValidarUsuario() => ServicioValidarUsuario.ValidarUsuario(UsuarioXarxa);
    }
}
