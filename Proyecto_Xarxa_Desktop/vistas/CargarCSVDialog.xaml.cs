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
    /// Lógica de interacción para CargarCSVDialog.xaml
    /// </summary>
    public partial class CargarCSVDialog : Window
    {
        private CargarCSVDialogVM vm = new CargarCSVDialogVM();
        public CargarCSVDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }

        private void CargarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.HacerCarga();
        }
    }
}
