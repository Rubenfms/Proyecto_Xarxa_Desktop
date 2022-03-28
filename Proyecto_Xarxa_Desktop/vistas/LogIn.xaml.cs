using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
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
using System.Windows.Shapes;

namespace Proyecto_Xarxa_Desktop.vistas
{
    /// <summary>
    /// Lógica de interacción para LogIn2.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private LogInVM vm = new LogInVM();
        public LogIn()
        {
            InitializeComponent();
            DataContext = vm;
            ServicioCargarDatos.CargarDatos();
        }

        private void EntrarButton_Click(object sender, RoutedEventArgs e)
        {
            // Si el usuario es valido, entramos al sistema
            if(vm.ValidarUsuario()) new MainWindow().Show();
        }

        // Hace se pueda arrastrar la pantalla
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
