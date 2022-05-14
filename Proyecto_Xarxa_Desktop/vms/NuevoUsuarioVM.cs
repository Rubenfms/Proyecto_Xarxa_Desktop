using Microsoft.Toolkit.Mvvm.ComponentModel;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de NuevoUsuarioDialog.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class NuevoUsuarioVM : ObservableObject
    {
        // Campos conectados a los dos textblocks de las contraseñas        
        /// <summary>
        /// Campo conectado al primer textblock de contrasenya.
        /// </summary>
        private String password1;

        /// <summary>
        /// Gets or sets the password1.
        /// </summary>
        /// <value>
        /// Campo conectado al primer textblock de contrasenya.
        /// </value>
        public String Password1
        {
            get { return password1; }
            set { password1 = value; }
        }

        /// <summary>
        /// Campo conectado al segundo textblock de contrasenya.
        /// </summary>
        private String password2;

        /// <summary>
        /// Gets or sets the password2.
        /// </summary>
        /// <value>
        /// Campo conectado al segundo textblock de contrasenya.
        /// </value>
        public String Password2
        {
            get { return password2; }
            set { password2 = value; }
        }

        /// <summary>
        /// El usuario que vamos a crear.
        /// </summary>
        private Usuario usuarioNuevo;

        /// <summary>
        /// Gets or sets the usuario nuevo.
        /// </summary>
        /// <value>
        /// El usuario que vamos a crear.
        /// </value>
        public Usuario UsuarioNuevo
        {
            get { return usuarioNuevo; }
            set { SetProperty(ref usuarioNuevo, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private ServicioAPI servicioApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="NuevoUsuarioVM"/> class.
        /// </summary>
        public NuevoUsuarioVM()
        {
            UsuarioNuevo = new Usuario();
            servicioApi = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        }

        /// <summary>
        /// Método que crea el nuevo usuario después de comprobar las credenciales.
        /// </summary>
        public void CrearUsuario()
        {
            bool usuarioCorrecto = ComprobarCredenciales();

            if(usuarioCorrecto)
            {
                UsuarioNuevo.Activo = true;
                HttpStatusCode? statusCode = servicioApi.PostUsuario(UsuarioNuevo);

                //ServicioDialogos.ServicioMessageBox($" Resultado de la creación del usuario: {statusCode}", "Operación completada", MessageBoxButton.OK, MessageBoxImage.Information);
                ServicioDialogos.ServicioMessageBox($" Resultado de la creación del usuario: {statusCode}", "Operación completada", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

        /// <summary>
        /// Comprueba las credenciales introducidas.
        /// </summary>
        /// <returns>Devuelve bool dependiendo de las credenciales. Si son correctas devolverá true.</returns>
        public bool ComprobarCredenciales()
        {
            // Comprobación de que se ha introducido un usuario
            if (UsuarioNuevo.NombreUsuario == null || UsuarioNuevo.NombreUsuario.Length == 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce un nombre de usuario", "Error de nombre de usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            // Comprobación de que se han introducido las dos contraseñas
            else if (Password1 == null || Password1.Equals("") || Password2 == null || Password2.Equals(""))
            {
                ServicioDialogos.ServicioMessageBox("Introduce una contraseña", "Error de contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            // Comprobación de si se ha introducido un tipo usuario
            else if (UsuarioNuevo.TipoUsuario == null)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un tipo de usuario", "Error de tipo de usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            // Comprobación de si las dos contraseñas son iguales
            else if (!Password1.Equals(Password2))
            {
                ServicioDialogos.ServicioMessageBox("Las dos contraseñas no son iguales", "Error de contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                UsuarioNuevo.Contrasenya = Password1; // Añadimos la contraseña al objeto Usuario que vamos a crear
                UsuarioNuevo.Contrasenya = ServicioValidarUsuario.Sha256encrypt(UsuarioNuevo.Contrasenya); // Encriptamos la contraseña
                return true;
            }
        }
    }
}
