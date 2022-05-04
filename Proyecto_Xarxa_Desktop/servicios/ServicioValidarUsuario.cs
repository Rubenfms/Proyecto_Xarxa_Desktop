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
    class ServicioValidarUsuario
    {
        private static Usuario usuarioActual;

        public static Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        ServicioAPI servicioApi;
        public ServicioValidarUsuario()
        {
            servicioApi = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        }

        // Método que recibe un usuario introducido en el formulario de LogIn y lo compara con el que devuelve la API a partir de su nickname
        public bool ValidarUsuario(Usuario UsuarioAValidar)
        {
            try
            {
                Usuario usuarioBD = servicioApi.GetUsuario(UsuarioAValidar.NombreUsuario);

                string hashedPass = Sha256encrypt(UsuarioAValidar.Contrasenya);
                if (usuarioBD.Contrasenya.Equals(hashedPass) && usuarioBD.NombreUsuario.Equals(UsuarioAValidar.NombreUsuario))
                {
                    UsuarioActual = usuarioBD;
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
            ServicioDialogos.ServicioMessageBox("Usuario o contraseña incorrectos", "Credenciales Incorrectas", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            return false;
        }
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
