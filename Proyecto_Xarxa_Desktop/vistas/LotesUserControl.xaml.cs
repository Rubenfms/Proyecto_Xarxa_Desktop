using Proyecto_Xarxa_Desktop.modelo;
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

        /// <summary>
        /// Handles the TextChanged event of the Buscador control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void Buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = Buscador.Text.ToUpper();
            foreach (Lote l in vm.ListaLotes)
            {
                if (l.IdLote.ToString().Contains(filtro) || l.ModalidadLote.Nombre.ToUpper().Contains(filtro) ||
                    l.NiaAlumno.ToString().Contains(filtro))
                {
                    listview.Items.Add(l);
                }
            }
        }


        private void CrearModalidadButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AbrirVistaCrearModalidad();
        }

        /// <summary>
        /// Handles the Click event of the LotesAsignadosRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void LotesAsignadosRadioButton_Click(object sender, RoutedEventArgs e)
        {
            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = Buscador.Text.ToUpper();
            foreach (Lote l in vm.ListaLotes)
            {
                if (l.NiaAlumno > 0)
                {
                    listview.Items.Add(l);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the LotesNoAsignadosRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void LotesNoAsignadosRadioButton_Click(object sender, RoutedEventArgs e)
        {
            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            foreach (Lote l in vm.ListaLotes)
            {
                if (l.NiaAlumno == null || l.NiaAlumno == 0)
                {
                    listview.Items.Add(l);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the SinFiltroRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SinFiltroRadioButton_Click(object sender, RoutedEventArgs e)
        {
            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = Buscador.Text.ToUpper();
            foreach (Lote l in vm.ListaLotes)
            {
                listview.Items.Add(l);   
            }
        }
    }
}
