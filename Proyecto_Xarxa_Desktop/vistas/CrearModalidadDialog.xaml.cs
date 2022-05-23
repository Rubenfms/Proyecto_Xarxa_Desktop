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
    /// Lógica de interacción para CrearModalidadDialog.xaml
    /// </summary>
    public partial class CrearModalidadDialog : Window
    {
        /// <summary>
        /// El vm de CrearModalidadDialog
        /// </summary>
        private CrearModalidadVM vm = new CrearModalidadVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="CrearModalidadDialog"/> class.
        /// </summary>
        public CrearModalidadDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the AnyadirLibroButton control.
        /// Abre una nueva ventana para añadir un libro a la lista de libros de la nueva modalidad.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AnyadirLibroButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AbrirVistaAnyadirLibro();
        }

        private void EliminarLibroButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarLibro();
        }

        private void GuardarModalidadButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultDialog = vm.GuardarModalidad();
            if (resultDialog) DialogResult = resultDialog;
        }
    }
}
