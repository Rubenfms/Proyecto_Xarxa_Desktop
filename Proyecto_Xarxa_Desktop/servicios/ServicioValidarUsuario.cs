using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        // Método que recibe un usuario introducido en el formulario de LogIn y devuelve true si se encuentra en la BD 
        public static bool ValidarUsuario(Usuario UsuarioAValidar)
        {
            // TODO: Hacer llamada a la api getOne Usuario y comprueba su contraseña
            foreach(Usuario u in ServicioCargarDatos.ListaUsuarios)
            {
                string hashedPass = Sha256encrypt(UsuarioAValidar.Contrasenya);
                if (u.Contrasenya.Equals(hashedPass) && u.NombreUsuario.Equals(UsuarioAValidar.NombreUsuario))
                {
                    UsuarioActual = u;
                    return true;
                }
            }
            return false;
        }
        public static string Sha256encrypt(string phrase)
        {
            using (SHA256 sha256Hash = SHA256.Create())
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
        }
    }
}
