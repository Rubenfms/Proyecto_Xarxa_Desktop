using Proyecto_Xarxa_Desktop.servicios;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Xarxa_Desktop.vistas
{
    /// <summary>
    /// Lógica de interacción para LotesUserControl.xaml
    /// </summary>
    public partial class LotesUserControl : UserControl
    {
        /// <summary>
        /// VM de Lotes
        /// </summary>
        private readonly LotesVM vm = new LotesVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="LotesUserControl"/> class.
        /// </summary>
        public LotesUserControl()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void CrearModalidadButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AbrirVistaCrearModalidad();
        }
    }
}
