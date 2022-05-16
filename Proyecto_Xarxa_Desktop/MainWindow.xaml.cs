using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vistas;
using Proyecto_Xarxa_Desktop.vms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Xarxa_Desktop
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// VM de MainWindow
        /// </summary>
        private MainWindowVM vm = new MainWindowVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        // Evento para salir de la aplicación        
        /// <summary>
        /// Handles the Click event of the SalirButton control.
        /// Evento para salir de la aplicación
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SalirButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        /// <summary>
        /// Handles the Click event of the CerrarSesionButton control.
        /// Evento para cerrar sesión.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            vm.CerrarSesion();
            this.Close(); // cerrar ventana
        }

        /// <summary>
        /// Handles the Click event of the CerrarMenuButton control.
        /// Evento para cerrar el menú lateral.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CerrarMenuButton_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenuButton.Visibility = Visibility.Visible;
            CerrarMenuButton.Visibility = Visibility.Collapsed;
            BalmisImagen.Visibility = Visibility.Collapsed;
            NombreUsuarioTB.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles the Click event of the AbrirMenuButton control.
        /// Evento para abrir el menú lateral.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AbrirMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CerrarMenuButton.Visibility = Visibility.Visible;
            AbrirMenuButton.Visibility = Visibility.Collapsed;
            BalmisImagen.Visibility = Visibility.Visible;
            NombreUsuarioTB.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Handles the Click event of the OpcionesSUButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OpcionesSUButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AbrirOpcionesSU();
        }

        /// <summary>
        /// Handles the Click event of the DarDeAltaButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void DarDeAltaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AbrirVistaDarDeAltaAlumno();
        }

        /// <summary>
        /// Handles the Click event of the DocTecnicaButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void DocTecnicaButton_Click(object sender, RoutedEventArgs e)
        {
            string helpFileName = @"..\..\..\help\documentacion\Help\Documentation.chm";

            if (System.IO.File.Exists(helpFileName))
            {
                System.Diagnostics.Process.Start(helpFileName);
            }
        }

        /// <summary>
        /// Handles the Click event of the AyudaButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AyudaButton_Click(object sender, RoutedEventArgs e)
        {
            string helpFileName = @"..\..\..\help\manual\Manual_Usuario_Xarxa.chm";

            if (System.IO.File.Exists(helpFileName))
            {
                System.Diagnostics.Process.Start(helpFileName);
            }
        }
    }
}
