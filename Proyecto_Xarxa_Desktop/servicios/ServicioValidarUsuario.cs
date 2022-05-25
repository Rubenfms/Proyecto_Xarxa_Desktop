using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Servicio para validar las credenciales que introduce en la pantalla LogIn un usuario
    /// </summary>
    class ServicioValidarUsuario
    {
        /// <summary>
        /// The usuario actual
        /// </summary>
        private static Usuario usuarioActual;

        /// <summary>
        /// Gets or sets the usuario actual.
        /// </summary>
        /// <value>
        /// The usuario actual.
        /// </value>
        public static Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        readonly ServicioAPI servicioApi;
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioValidarUsuario"/> class.
        /// </summary>
        public ServicioValidarUsuario()
        {
            servicioApi = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        }

        /// <summary>
        ///  Método que recibe un usuario introducido en el formulario de LogIn y lo compara con el que devuelve la API a partir de su nickname
        /// </summary>
        /// <param name="UsuarioAValidar">The usuario a validar.</param>
        /// <returns>Devuelve true o false dependiendo de si el usuario introducido es igual que el de la BD</returns>
        public bool ValidarUsuario(Usuario UsuarioAValidar)
        {
            try
            {
                Application.Current.Resources["sessionId"] = servicioApi.LoginUsuario(UsuarioAValidar.NombreUsuario, Sha256encrypt(UsuarioAValidar.Contrasenya));

                if (Application.Current.Resources["sessionId"].ToString().Length > 0)
                {

                    Usuario usuarioBD = servicioApi.GetUsuario(UsuarioAValidar.NombreUsuario);

                    string hashedPass = Sha256encrypt(UsuarioAValidar.Contrasenya);
                    if (usuarioBD.Contrasenya.Equals(hashedPass) && usuarioBD.NombreUsuario.Equals(UsuarioAValidar.NombreUsuario))
                    {
                        UsuarioActual = usuarioBD;

                        Application.Current.Resources["UsuarioLogeado"] = UsuarioActual;
                        return true;
                    }
                }
            }
            catch (NullReferenceException)
            {
                ServicioDialogos.ServicioMessageBox("El usuario introducido está registrado en el sistema", "Usuario no encontrado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
            ServicioDialogos.ServicioMessageBox("Usuario o contraseña incorrectos", "Credenciales Incorrectas", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            return false;
        }

        /// <summary>
        /// Sha256encrypts the specified phrase.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns>Frase encriptada.</returns>
        public static string Sha256encrypt(string phrase)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                try
                {
                    // ComputeHash - returns byte array
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(phrase));

                    // Convert byte array to a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
                catch (NullReferenceException)
                {
                    ServicioDialogos.ServicioMessageBox("Tienes que introducir una contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                    throw;
                }
                catch (Exception)
                {
                    ServicioDialogos.ServicioMessageBox("Error al tratar la contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }
    }
}
