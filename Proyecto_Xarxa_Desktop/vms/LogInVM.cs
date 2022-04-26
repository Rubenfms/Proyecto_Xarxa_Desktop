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
using System.Windows;

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
            servicioValidarUsuario = new ServicioValidarUsuario();
            ValidarUsuarioCommand = new RelayCommand(ValidarUsuario);
        }

        public void ValidarUsuario()
        {
            UsuarioXarxa.Contrasenya = Password;
            if (UsuarioXarxa.NombreUsuario == null || UsuarioXarxa.NombreUsuario.Length == 0)
                ServicioDialogos.ServicioMessageBox("Tienes que introducir un usuario", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            else if (UsuarioXarxa.Contrasenya == null || UsuarioXarxa.Contrasenya.Length == 0)
                ServicioDialogos.ServicioMessageBox("Tienes que introducir una contraseña", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            // Si el usuario es valido, entramos al sistema
            else
            {
                if (servicioValidarUsuario.ValidarUsuario(UsuarioXarxa))
                {
                    new MainWindow().Show();

                    // Recorre las ventanas existentes y cierra la de login
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == this) item.Close();
                    }
                }
            }
        }
    }
}
