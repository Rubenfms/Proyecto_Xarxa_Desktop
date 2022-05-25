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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Spreadsheet Files|*.csv;*.xls;*.xlsm;*.xlsx;" // Se recomienda CSV
            };


            bool? resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                archivoSeleccionado = openFileDialog.FileName;
                return archivoSeleccionado;
            }
            else
            {
                ServicioMessageBox($"No se ha podido cargar el archivo seleccionado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }

        /// <summary>
        /// Servicio del message box con todos los parámetros.
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
        /// Servicio del message box con todos los parámetros menos la imagen.
        /// </summary>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="titulo">The titulo.</param>
        /// <param name="boxButton">The box button.</param>
        public static void ServicioMessageBoxWithoutImage(string mensaje, string titulo, MessageBoxButton boxButton)
        {
            MessageBox.Show(mensaje, titulo, boxButton);
        }
        /// <summary>
        /// Servicio del message box con todos los parámetros con resultado.
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
