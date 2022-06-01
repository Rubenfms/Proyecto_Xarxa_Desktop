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
    /// Interaction logic for BorrarModalidadDialog.xaml
    /// </summary>
    public partial class BorrarModalidadDialog : Window
    {
        BorrarModalidadVM vm = new BorrarModalidadVM();

        public BorrarModalidadDialog()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void ComboBoxModalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modalidad modalidadSeleccionada = (Modalidad)ModalidadComboBox.SelectedItem;

            // Añadido condicional para que no de conflicto al limpiar la selección
            if (modalidadSeleccionada != null)
            {
                // Mostramos el listbox con todas las modalidades
                vm.CargarModalidades(modalidadSeleccionada.Nombre);
            }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
