using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Servicio de diálogos de windows
    /// </summary>
    class ServicioDialogos
    {
        /// <summary>
        /// The archivo seleccionado
        /// </summary>
        private static string archivoSeleccionado;

        /// <summary>
        /// Gets or sets the archivo seleccionado.
        /// </summary>
        /// <value>
        /// The archivo seleccionado.
        /// </value>
        public static string ArchivoSeleccionado { get => archivoSeleccionado; set => archivoSeleccionado = value; }

        /// <summary>
        /// Opens the file dialog service.
        /// </summary>
        public static string OpenFileDialogService()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Spreadsheet Files|*.csv;*.xls;*.xlsm;*.xlsx;"; // Se recomienda CSV


            bool? resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                ServicioMessageBox($"Archivo {openFileDialog.SafeFileName} cargado", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                archivoSeleccionado = openFileDialog.FileName;
                return archivoSeleccionado;
            }
            else return "";
        }

        /// <summary>
        /// Servicioes the message box.
        /// </summary>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="titulo">The titulo.</param>
        /// <param name="boxButton">The box button.</param>
        /// <param name="messageBoxImage">The message box image.</param>
        public static void ServicioMessageBox(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);
        }

        /// <summary>
        /// Servicioes the message box result.
        /// </summary>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="titulo">The titulo.</param>
        /// <param name="boxButton">The box button.</param>
        /// <param name="messageBoxImage">The message box image.</param>
        /// <returns></returns>
        public static MessageBoxResult ServicioMessageBoxResult(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
            => MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);

        /// <summary>
        /// Mensajes the alerta.
        /// </summary>
        /// <param name="mensaje">The mensaje.</param>
        public static void MensajeAlerta(string mensaje) => MessageBox.Show(mensaje, "Atención", MessageBoxButton.OK);
    }
}
