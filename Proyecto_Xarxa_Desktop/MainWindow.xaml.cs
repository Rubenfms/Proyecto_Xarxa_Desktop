using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vistas;
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
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Alumno> listaAlumnos = ServicioCsv.GetListaAlumnos();
            new LogIn().Show();
        }

        private void SalirButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CerrarMenuButton_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenuButton.Visibility = Visibility.Visible;
            CerrarMenuButton.Visibility = Visibility.Collapsed;
            BalmisImagen.Visibility = Visibility.Collapsed;
        }

        private void AbrirMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CerrarMenuButton.Visibility = Visibility.Visible;
            AbrirMenuButton.Visibility = Visibility.Collapsed;
            BalmisImagen.Visibility = Visibility.Visible;

        }
    }
}
