using Proyecto_Xarxa_Desktop.informes;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System.Collections.ObjectModel;

using System.Windows;


namespace Proyecto_Xarxa_Desktop.vistasInformes
{
    /// <summary>
    /// Lógica de interacción para InformeXarxaGrupos.xaml
    /// </summary>
    public partial class InformeXarxaGrupos : Window
    {
        public InformeXarxaGrupos()
        {
            InitializeComponent();
            GenerarInforme();

        }

        private void GenerarInforme()
        {
            reportViewerGrupos.Owner = this;
            ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            XarxaGruposReport informe = new XarxaGruposReport();
            ObservableCollection<Alumno> alumnos = servicioAPI.GetAlumnos();
            informe.SetDataSource(alumnos);
            reportViewerGrupos.ViewerCore.ReportSource = informe;
        }
    }
}
