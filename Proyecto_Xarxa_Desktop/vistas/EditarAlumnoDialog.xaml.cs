﻿using Proyecto_Xarxa_Desktop.vms;
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
    /// Lógica de interacción para EditarAlumnoDialog.xaml
    /// </summary>
    public partial class EditarAlumnoDialog : Window
    {

        private readonly EditarAlumnoVM vm;
        /// <summary>
        /// Initializes a new instance of the <see cref="EditarAlumnoDialog"/> class.
        /// </summary>
        public EditarAlumnoDialog()
        {
            vm = new EditarAlumnoVM();
            this.DataContext = vm;
            InitializeComponent();
        }

        private void EditarAlumno_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}
