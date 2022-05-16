using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de Administrar Usuarios
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class AdministrarUsuariosVM : ObservableObject
    {
        /// <summary>
        /// La lista de usuarios
        /// </summary>
        private ObservableCollection<Usuario> listaUsuarios;

        /// <summary>
        /// Gets or sets the lista usuarios.
        /// </summary>
        /// <value>
        /// La lista de usuarios.
        /// </value>
        public ObservableCollection<Usuario> ListaUsuarios
        {
            get { return listaUsuarios; }
            set { SetProperty(ref listaUsuarios, value); }
        }

        /// <summary>
        /// El usuario seleccionado que vamos a desactivar o activar.
        /// </summary>
        private Usuario usuarioSeleccionado;

        /// <summary>
        /// Gets or sets the usuario seleccionado.
        /// </summary>
        /// <value>
        /// El usuario seleccionado que vamos a desactivar o activar.
        /// </value>
        public Usuario UsuarioSeleccionado
        {
            get { return usuarioSeleccionado; }
            set { SetProperty(ref usuarioSeleccionado, value); }
        }

        /// <summary>
        /// Gets the activar usuario command.
        /// </summary>
        /// <value>
        /// The activar usuario command.
        /// </value>
        public RelayCommand ActivarUsuarioCommand { get; }

        /// <summary>
        /// Gets the desactivar usuario command.
        /// </summary>
        /// <value>
        /// The desactivar usuario command.
        /// </value>
        public RelayCommand DesactivarUsuarioCommand { get; }

        /// <summary>
        /// El servicio API
        /// </summary>
        private ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        public AdministrarUsuariosVM()
        {
            ListaUsuarios = servicioAPI.GetUsuarios();

            // Comandos
            ActivarUsuarioCommand = new RelayCommand(ActivarUsuario);
            DesactivarUsuarioCommand = new RelayCommand(DesactivarUsuario);
        }

        public void ActivarUsuario()
        {
            if(UsuarioSeleccionado.Activo)
            {
                ServicioDialogos.ServicioMessageBox("El usuario ya está activado", "Usuario Activo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            else
            {
                UsuarioSeleccionado.Activo = true;
                HttpStatusCode? statusCode = servicioAPI.PutUsuario(UsuarioSeleccionado);
                ServicioDialogos.ServicioMessageBox($"Resultado de la actualización del usuario: {statusCode}", "Resultado actualización", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void DesactivarUsuario()
        {
            if(!UsuarioSeleccionado.Activo)
            {
                ServicioDialogos.ServicioMessageBox("El usuario ya está desactivado", "Usuario Inactivo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            else
            {
                UsuarioSeleccionado.Activo = false;
                HttpStatusCode? statusCode = servicioAPI.PutUsuario(UsuarioSeleccionado);
                ServicioDialogos.ServicioMessageBox($"Resultado de la actualización del usuario: {statusCode}", "Resultado actualización", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
