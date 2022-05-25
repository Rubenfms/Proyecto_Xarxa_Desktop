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
    /// <summary>
    /// VM de LogIn.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class LogInVM : ObservableObject
    {
        /// <summary>
        /// Usuario que crearemos a partir de las credenciales introducidas por el usuario para comprobar posteriormente si existe en la BD
        /// </summary>
        private Usuario usuarioXarxa;

        /// <summary>
        /// Gets or sets the usuario xarxa.
        /// </summary>
        /// <value>
        /// Usuario a partir de las credenciales introducidas por el usuario
        /// </value>
        public Usuario UsuarioXarxa
        {
            get { return usuarioXarxa; }
            set { SetProperty(ref usuarioXarxa, value); }
        }

        /// <summary>
        /// Gets the validar usuario command.
        /// </summary>
        /// <value>
        /// The validar usuario command.
        /// </value>
        public RelayCommand ValidarUsuarioCommand { get; }

        /// <summary>
        /// The servicio validar usuario
        /// </summary>
        private readonly ServicioValidarUsuario servicioValidarUsuario;

        /// <summary>
        /// Campo necesario para la contraseña al ser SecureBox
        /// </summary>
        private String securePassword;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// Campo necesario para la contraseña al ser SecureBox
        /// </value>
        public String Password
        {
            get { return securePassword; }
            set { SetProperty(ref securePassword, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogInVM"/> class.
        /// </summary>
        public LogInVM()
        {
            UsuarioXarxa = new Usuario();
            servicioValidarUsuario = new ServicioValidarUsuario();
            ValidarUsuarioCommand = new RelayCommand(ValidarUsuario);
        }

        /// <summary>
        /// Método que valida si el usuario creado a partir de las credenciales introducidas por el usuario existe en la BD o no
        /// </summary>
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
