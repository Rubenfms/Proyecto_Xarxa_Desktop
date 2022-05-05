using Microsoft.Win32;
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
        private static string archivoSeleccionado;

        public static string ArchivoSeleccionado { get => archivoSeleccionado; set => archivoSeleccionado = value; }

        public static void OpenFileDialogService()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Spreadsheet Files|*.csv;*.xls;*.xlsm;*.xlsx;"; // Se recomienda CSV


            bool? resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                archivoSeleccionado = openFileDialog.FileName;
                ServicioMessageBox($"Archivo {openFileDialog.SafeFileName} cargado", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void ServicioMessageBox(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);
        }

        public static MessageBoxResult ServicioMessageBoxResult(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
            => MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);
    }
}
