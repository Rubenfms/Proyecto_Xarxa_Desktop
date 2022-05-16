using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_Xarxa_Desktop.vistas
{
    /// <summary>
    /// Lógica de interacción para NuevoUsuarioDialog.xaml
    /// </summary>
    public partial class NuevoUsuarioDialog : Window
    {
        /// <summary>
        /// VM de Nuevo Usuario
        /// </summary>
        private NuevoUsuarioVM vm = new NuevoUsuarioVM();

        // Campos para las dos contraseñas        
        /// <summary>
        /// The password1
        /// </summary>
        private SecureString password1;

        /// <summary>
        /// Gets or sets the password1.
        /// </summary>
        /// <value>
        /// El valor del securebox de la primera contraseña.
        /// </value>
        public SecureString Password1
        {
            get { return password1; }
            set { password1 = value; }
        }

        /// <summary>
        /// The password2
        /// </summary>
        private SecureString password2;

        /// <summary>
        /// Gets or sets the password2.
        /// </summary>
        /// <value>
        /// El valor del securebox de la segunda contraseña.
        /// </value>
        public SecureString Password2
        {
            get { return password2; }
            set { password2 = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NuevoUsuarioDialog"/> class.
        /// </summary>
        public NuevoUsuarioDialog()
        {
            InitializeComponent();
            DataContext = vm;
        }

        /// <summary>
        /// Handles the Click event of the CrearUsuarioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CrearUsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            vm.CrearUsuario();
        }

        // Se asignan al cambiarse la contraseña porque no consigo que funcione en el momento de clickar el boton        
        /// <summary>
        /// Handles the PasswordChanged event of the PasswordBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Actualiza la propiedad Password1 del vm con la password que esta siendo introducida en el primer SecureBox
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password1 = ((PasswordBox)sender).Password;

            }
            else
            {
                ServicioDialogos.ServicioMessageBox("No hay un data context asignado a la ventana", "Error de contexto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the PasswordChanged event of the PasswordBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void PasswordBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Actualiza la propiedad Password2 del vm con la password que esta siendo introducida en el segundo SecureBox
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password2 = ((PasswordBox)sender).Password;

            }
            else
            {
                ServicioDialogos.ServicioMessageBox("No hay un data context asignado a la ventana", "Error de contexto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
