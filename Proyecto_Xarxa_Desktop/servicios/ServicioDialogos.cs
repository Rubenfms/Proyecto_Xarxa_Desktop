using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.servicios
{
    class ServicioDialogos
    {
        public static void ServicioMessageBox(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);
        }

        public static MessageBoxResult ServicioMessageBoxResult(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
            => MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);
    }
}
