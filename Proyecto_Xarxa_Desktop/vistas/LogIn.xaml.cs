using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para LogIn2.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        /// <summary>
        /// VM de LogIn.
        /// </summary>
        private LogInVM vm = new LogInVM();

        /// <summary>
        /// El campo de la contraseña.
        /// </summary>
        private SecureString password;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// Propiedad bindeada al secure box de la contraseña.
        /// </value>
        public SecureString Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogIn"/> class.
        /// </summary>
        public LogIn()
        {
            InitializeComponent();
            DataContext = vm;
        }

        // Hace se pueda arrastrar la pantalla        
        /// <summary>
        /// Handles the MouseDown event of the Grid control.
        /// Hace que se pueda arrastrar la pantalla.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// Handles the PasswordChanged event of the PasswordBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Actualiza la propiedad Password del vm con la password que esta siendo introducida en el SecureBox
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
