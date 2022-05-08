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
    /// Lógica de interacción para AsignarLoteDialog.xaml
    /// </summary>
    public partial class AsignarLoteDialog : Window
    {
        private AsignarLoteVM vm = new AsignarLoteVM();
        public AsignarLoteDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }

        private void buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            MiListbox.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            MiListbox.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = buscador.Text.ToUpper();
            foreach (int a in vm.ListaNias)
            {
                if (a.ToString().Contains(filtro))
                {
                    MiListbox.Items.Add(a);
                }
            }
        }
    }
}
