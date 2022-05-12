using Proyecto_Xarxa_Desktop.informes;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Proyecto_Xarxa_Desktop.vistasInformes
{
    public partial class InformeXarxaCompleto : Window
    {
        public InformeXarxaCompleto()
        {
            InitializeComponent();
            GenerarInforme();
           
        }

        private void GenerarInforme()
        {
            reportViewerXarxa.Owner = this;
            ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            XarxaCompletoReport informe = new XarxaCompletoReport();
            ObservableCollection<Alumno> alumnos = servicioAPI.GetAlumnos();
            informe.SetDataSource(alumnos);
            reportViewerXarxa.ViewerCore.ReportSource = informe;
        }

    }
}
