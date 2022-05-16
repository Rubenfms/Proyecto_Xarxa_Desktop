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
    /// Lógica de interacción para GenerarLote.xaml
    /// </summary>
    public partial class GenerarLote : Window
    {
        /// <summary>
        /// VM de Generar Lote
        /// </summary>
        private GenerarLoteVM vm = new GenerarLoteVM();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerarLote"/> class.
        /// </summary>
        public GenerarLote()
        {
            InitializeComponent();
            DataContext = vm;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the ComboBoxModalidad control.
        /// Dependiendo de la modalidad seleccionada carga los libros de dicha modalidad.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void ComboBoxModalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modalidad modalidadSeleccionada = (Modalidad)ModalidadComboBox.SelectedItem;

            // Añadido condicional para que no de conflicto al limpiar la selección
            if (modalidadSeleccionada != null)
            {
                // Mostramos el listbox con todas las modalidades
                vm.CargarModalidades(modalidadSeleccionada.Nombre);
                // Generamos numero lote
                vm.GenerarNumeroLote(modalidadSeleccionada);
            }
        }
    }
}
