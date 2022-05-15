using Proyecto_Xarxa_Desktop.informes;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System.Collections.ObjectModel;

using System.Windows;


namespace Proyecto_Xarxa_Desktop.vistasInformes
{
    /// <summary>
    /// Lógica de interacción para InformeLotes.xaml
    /// </summary>
    public partial class InformeLotes : Window
    {
        public InformeLotes()
        {
            InitializeComponent();
            GenerarInforme();
        }

        private void GenerarInforme()
        {
            reportViewerLotes.Owner = this;
            ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            LotesReport informe = new LotesReport();
            ObservableCollection<Modalidad> modalidades = servicioAPI.GetModalidades();
            informe.SetDataSource(modalidades);

            reportViewerLotes.ViewerCore.ReportSource = informe;
        }
    }
}
