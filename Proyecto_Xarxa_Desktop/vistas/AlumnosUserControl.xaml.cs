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
        private AlumnosVM vm = new AlumnosVM();
        public AlumnosUserControl()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void buscador_TextChanged(object sender, TextChangedEventArgs e)
        {
            listview.ClearValue(ListView.ItemsSourceProperty); // Eliminamos el valor de la propiedad Items Source para poder usar Clear items
            listview.Items.Clear(); // Eliminamos los items actuales antes de añadir los nuevos filtrados


            // Filtramos y mostramos el resultado filtrado
            string filtro = buscador.Text.ToUpper();
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
    }
}
