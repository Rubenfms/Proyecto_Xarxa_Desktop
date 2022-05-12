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
        private NuevoUsuarioVM vm = new NuevoUsuarioVM();
        // Campos para las dos contraseñas
        private SecureString password1;

        public SecureString Password1
        {
            get { return password1; }
            set { password1 = value; }
        }

        private SecureString password2;

        public SecureString Password2
        {
            get { return password2; }
            set { password2 = value; }
        }


        public NuevoUsuarioDialog()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void CrearUsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            vm.CrearUsuario();
        }

        // Se asignan al cambiarse la contraseña porque no consigo que funcione en el momento de clickar el boton
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
