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
        private DarDeAltaAlumnoVM vm = new DarDeAltaAlumnoVM();
        public DarDeAltaDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }

        private void SeleccionBusquedaPorNiaButton_Click(object sender, RoutedEventArgs e)
        {
            ContenedorInicial.Visibility = Visibility.Collapsed;
            ContenedorBuscarPorNia.Visibility = Visibility.Visible; // Mostramos el contenedor para buscar por nia
            ContenedorBuscarPorNombre.Visibility = Visibility.Collapsed;
            VolverAtrasButton.Visibility = Visibility.Visible;
        }

        private void SeleccionBusquedaPorNombreButton_Click(object sender, RoutedEventArgs e)
        {
            ContenedorInicial.Visibility = Visibility.Collapsed;
            ContenedorBuscarPorNia.Visibility = Visibility.Collapsed; 
            ContenedorBuscarPorNombre.Visibility = Visibility.Visible; // Mostramos el contenedor para buscar por nombre y apellidos
            VolverAtrasButton.Visibility = Visibility.Visible;
        }
        private void VolverAtrasButton_Click(object sender, RoutedEventArgs e)
        {
            ContenedorInicial.Visibility = Visibility.Visible; // Mostramos el contenedor para seleccionar la opción
            ContenedorBuscarPorNia.Visibility = Visibility.Collapsed;
            ContenedorBuscarPorNombre.Visibility = Visibility.Collapsed;
            VolverAtrasButton.Visibility = Visibility.Collapsed;
        }

        private void BuscarPorNiaButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultDialog = vm.BuscarPorNia();
            DialogResult = resultDialog;
        }

        private void BuscarPorNombreButton_Click(object sender, RoutedEventArgs e)
        {
            vm.BuscarPorNombre();
        }
    }
}
