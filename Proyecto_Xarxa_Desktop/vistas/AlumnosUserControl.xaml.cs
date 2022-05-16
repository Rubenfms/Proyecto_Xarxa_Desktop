using Proyecto_Xarxa_Desktop.modelo;
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
    /// Lógica de interacción para AlumnosUserControl.xaml
    /// </summary>
    public partial class AlumnosUserControl : UserControl
    {
        /// <summary>
        /// VM de Alumnos VM
        /// </summary>
        private AlumnosVM vm = new AlumnosVM();
        /// <summary>
        /// Initializes a new instance of the <see cref="AlumnosUserControl"/> class.
        /// </summary>
        public AlumnosUserControl()
        {
            InitializeComponent();
            DataContext = vm;
        }

        /// <summary>
        /// Handles the TextChanged event of the buscador control.
        /// Filtra en la lista de alumnos lo que le hayan pasado (NIA, Nombre, Apellidos o Grupo).
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void Buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = Buscador.Text.ToUpper();
            foreach (Alumno a in vm.ListaAlumnos)
            {
                if (a.Nombre.ToUpper().Contains(filtro) || a.Nia.ToString().Contains(filtro) ||
                    a.Apellido1.ToUpper().Contains(filtro) || a.Apellido2.ToUpper().Contains(filtro) ||
                    a.Grupo.ToUpper().Contains(filtro))
                {
                    listview.Items.Add(a);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the DarDeBajaButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void DarDeBajaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.DarDeBaja();
        }

        /// <summary>
        /// Handles the Click event of the SoloXarxaRadioButton control.
        /// Filtra la lista por solo alumnos que estén en la Xarxa.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SoloXarxaRadioButton_Click(object sender, RoutedEventArgs e)
        {

            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados

            // Mostramos alumnos solo que sean de la Xarxa
            foreach (Alumno a in vm.ListaAlumnos)
            {
                // Si el botón está activo mostramos solo los alumnos que pertenezcan a la xarxa
                if ((bool)SoloXarxaRadioButton.IsChecked)
                {
                    if (a.PerteneceXarxa)
                    {
                        listview.Items.Add(a);
                    }
                }
                else listview.Items.Add(a); // Si no está checkeado mostramos todos
            }
        }

        /// <summary>
        /// Handles the Click event of the NoXarxaRadioButton control.
        /// Filtra la lista por solo alumnos que no estén en la Xarxa.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NoXarxaRadioButton_Click(object sender, RoutedEventArgs e)
        {

            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados

            // Mostramos alumnos solo que NO sean de la Xarxa
            foreach (Alumno a in vm.ListaAlumnos)
            {
                // Si el botón está activo mostramos solo los alumnos que NO pertenezcan a la xarxa
                if ((bool)NoXarxaRadioButton.IsChecked)
                {
                    if (!a.PerteneceXarxa)
                    {
                        listview.Items.Add(a);
                    }
                }
                else listview.Items.Add(a); // Si no está checkeado mostramos todos
            }
        }

        /// <summary>
        /// Handles the Click event of the SinFiltroRadioButton control.
        /// Quita todos los filtros y muestra la lista normal.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SinFiltroRadioButton_Click(object sender, RoutedEventArgs e)
        {

            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados

            // Mostramos todos los alumnos
            foreach (Alumno a in vm.ListaAlumnos)
            {
                if ((bool)SinFiltroRadioButton.IsChecked)
                {
                    listview.Items.Add(a); 
                }
            }
        }
    }
}
