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
        private LotesVM vm = new LotesVM();
        public LotesUserControl()
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
