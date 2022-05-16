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
        /// <summary>
        /// La VM de AsignarLote
        /// </summary>
        private AsignarLoteVM vm = new AsignarLoteVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="AsignarLoteDialog"/> class.
        /// </summary>
        public AsignarLoteDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the TextChanged event of the buscador control.
        /// Hace una busqueda en el listbox de lo que se vaya introduciendo.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void Buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            MiListbox.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            MiListbox.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = Buscador.Text.ToUpper();
            foreach (int a in vm.ListaNias)
            {
                if (a.ToString().Contains(filtro))
                {
                    MiListbox.Items.Add(a);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ConfirmarNiaButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ConfirmarNiaButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para cerrar el diálogo si el nia se ha asignado correctamente
            bool? result = vm.ConfirmarNia();
            if (result == true) DialogResult = true;
        }
    }
}
