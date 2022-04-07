using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
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

        public RelayCommand ValidarUsuarioCommand { get; }

        ServicioValidarUsuario servicioValidarUsuario;

        private String securePassword;

        public String Password
        {
            get { return securePassword; }
            set { SetProperty(ref securePassword, value); }
        }

        public LogInVM()
        {
            UsuarioXarxa = new Usuario();
            listaUsuarios = ServicioAPI.GetUsuarios();
            servicioValidarUsuario = new ServicioValidarUsuario();
            ValidarUsuarioCommand = new RelayCommand(ValidarUsuario);
        }

        public void ValidarUsuario()
        {
            UsuarioXarxa.Contrasenya = Password;
            // Si el usuario es valido, entramos al sistema
            if (servicioValidarUsuario.ValidarUsuario(UsuarioXarxa)) new MainWindow().Show();
        }
    }
}
