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
using System.Windows.Shapes;

namespace Proyecto_Xarxa_Desktop.vistas
{
    /// <summary>
    /// Lógica de interacción para AnyadirLibroModalidad.xaml
    /// </summary>
    public partial class AnyadirLibroModalidad : Window
    {
        /// <summary>
        /// El vm de AnyadirLibroModalidad
        /// </summary>
        private readonly AnyadirLibroModalidadVM vm = new AnyadirLibroModalidadVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyadirLibroModalidad"/> class.
        /// </summary>
        public AnyadirLibroModalidad()
        {
            DataContext = vm;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the TextChanged event of the Buscador control.
        /// Filtra el texto introducido por el usuario en el buscador.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void Buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            MiListbox.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            MiListbox.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados

            // Filtramos y mostramos el resultado filtrado
            string filtro = Buscador.Text.ToUpper();
            foreach (Libro l in vm.ListaLibros)
            {
                if (l.Titulo.Contains(filtro) || l.Isbn.Contains(filtro) || l.Editorial.Contains(filtro) || l.Departamento.Contains(filtro))
                {
                    MiListbox.Items.Add(l);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the AnyadirLibroButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AnyadirLibroButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AnyadirLibro();
        }
    }
}
