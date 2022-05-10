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
    class NuevoUsuarioVM : ObservableObject
    {
        // Campos conectados a los dos textblocks de las contraseñas
        private String password1;

        public String Password1
        {
            get { return password1; }
            set { password1 = value; }
        }

        private String password2;

        public String Password2
        {
            get { return password2; }
            set { password2 = value; }
        }

        private Usuario usuarioNuevo;

        public Usuario UsuarioNuevo
        {
            get { return usuarioNuevo; }
            set { SetProperty(ref usuarioNuevo, value); }
        }

        private ServicioAPI servicioApi;
        public NuevoUsuarioVM()
        {
            UsuarioNuevo = new Usuario();
            servicioApi = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
        }

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
