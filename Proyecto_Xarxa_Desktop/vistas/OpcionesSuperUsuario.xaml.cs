﻿using Proyecto_Xarxa_Desktop.servicios;
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
    /// Lógica de interacción para OpcionesSuperUsuario.xaml
    /// </summary>
    public partial class OpcionesSuperUsuario : Window
    {
        private OpcionesSuperUsuarioVM vm = new OpcionesSuperUsuarioVM();
        public OpcionesSuperUsuario()
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
