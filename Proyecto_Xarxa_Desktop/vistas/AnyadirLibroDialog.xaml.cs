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
    /// Lógica de interacción para AnyadirLibroDialog.xaml
    /// </summary>
    public partial class AnyadirLibroDialog : Window
    {
        /// <summary>
        /// La VM de AnyadirLibroDialog
        /// </summary>
        private AnyadirLibroVM vm = new AnyadirLibroVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyadirLibroDialog"/> class.
        /// </summary>
        public AnyadirLibroDialog()
        {
            DataContext = vm;
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Click event of the AnyadirLibroButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AnyadirLibroButton_Click(object sender, RoutedEventArgs e)
        {
            bool resultDialog = vm.AnyadirLibro();
            if (resultDialog) DialogResult = resultDialog;
        }
    }
}
