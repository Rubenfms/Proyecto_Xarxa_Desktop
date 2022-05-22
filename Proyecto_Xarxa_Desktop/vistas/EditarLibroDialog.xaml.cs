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
    /// Lógica de interacción para EditarLibroDialog.xaml
    /// </summary>
    public partial class EditarLibroDialog : Window
    {
        /// <summary>
        /// La vm de EditarLibroDialog.
        /// </summary>
        private EditarLibroVM vm = new EditarLibroVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="EditarLibroDialog"/> class.
        /// </summary>
        public EditarLibroDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the EditarLibroButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void EditarLibroButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultDialog = vm.EditarLibro();
            if (resultDialog) DialogResult = resultDialog;
        }
    }
}
