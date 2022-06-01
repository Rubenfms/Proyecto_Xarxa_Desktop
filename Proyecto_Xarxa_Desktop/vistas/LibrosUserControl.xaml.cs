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
    /// Lógica de interacción para LibrosUserControl.xaml
    /// </summary>
    public partial class LibrosUserControl : UserControl
    {
        /// <summary>
        /// VM de LibrosUserControl.
        /// </summary>
        private readonly LibrosVM vm = new LibrosVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="LibrosUserControl"/> class.
        /// </summary>
        public LibrosUserControl()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = Buscador.Text.ToUpper();
            foreach (Libro l in vm.ListaLibros)
            {
                if (l.Isbn.ToUpper().Contains(filtro) || l.Titulo.ToUpper().Contains(filtro) ||
                    l.Departamento.ToUpper().Contains(filtro) || l.Editorial.ToUpper().Contains(filtro) ||
                    l.Curso.ToString().ToUpper().Contains(filtro))
                {
                    listview.Items.Add(l);
                }
            }
        }

        private void EditarLibroButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AbrirVistaEditarLibro();
        }
    }
}
