using Proyecto_Xarxa_Desktop.vms;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Proyecto_Xarxa_Desktop.vistas
{
    /// <summary>
    /// Lógica de interacción para DarDeAltaDialog.xaml
    /// </summary>
    public partial class DarDeAltaDialog : Window
    {
        /// <summary>
        /// VM de Dar De Alta alumno
        /// </summary>
        private DarDeAltaAlumnoVM vm = new DarDeAltaAlumnoVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="DarDeAltaDialog"/> class.
        /// </summary>
        public DarDeAltaDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the SeleccionBusquedaPorNiaButton control.
        /// Establece la visibilidad del contenedor de buscar por NIA.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SeleccionBusquedaPorNiaButton_Click(object sender, RoutedEventArgs e)
        {
            ContenedorInicial.Visibility = Visibility.Collapsed;
            ContenedorBuscarPorNia.Visibility = Visibility.Visible; // Mostramos el contenedor para buscar por nia
            ContenedorBuscarPorNombre.Visibility = Visibility.Collapsed;
            VolverAtrasButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles the Click event of the SeleccionBusquedaPorNombreButton control.
        /// Establece la visibilidad del contenedor de buscar por Nombre.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SeleccionBusquedaPorNombreButton_Click(object sender, RoutedEventArgs e)
        {
            ContenedorInicial.Visibility = Visibility.Collapsed;
            ContenedorBuscarPorNia.Visibility = Visibility.Collapsed; 
            ContenedorBuscarPorNombre.Visibility = Visibility.Visible; // Mostramos el contenedor para buscar por nombre y apellidos
            VolverAtrasButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles the Click event of the VolverAtrasButton control.
        /// Vuelve atrás para establecer la visibilidad del primer contenedor.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void VolverAtrasButton_Click(object sender, RoutedEventArgs e)
        {
            ContenedorInicial.Visibility = Visibility.Visible; // Mostramos el contenedor para seleccionar la opción
            ContenedorBuscarPorNia.Visibility = Visibility.Collapsed;
            ContenedorBuscarPorNombre.Visibility = Visibility.Collapsed;
            VolverAtrasButton.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles the Click event of the BuscarPorNiaButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BuscarPorNiaButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultDialog = vm.BuscarPorNia();
            if (resultDialog) DialogResult = resultDialog;
        }

        /// <summary>
        /// Handles the Click event of the BuscarPorNombreButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BuscarPorNombreButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultDialog = vm.BuscarPorNombre();
            if(resultDialog) DialogResult = resultDialog;
        }
    }
}
