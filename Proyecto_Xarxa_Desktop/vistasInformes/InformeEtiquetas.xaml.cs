using Proyecto_Xarxa_Desktop.informes;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System.Collections.ObjectModel;

using System.Windows;

namespace Proyecto_Xarxa_Desktop.vistasInformes
{
    /// <summary>
    /// Lógica de interacción para InformeEtiquetas.xaml
    /// </summary>
    public partial class InformeEtiquetas : Window
    {
        public InformeEtiquetas()
        {
            InitializeComponent();
            GenerarInforme();
        }

        private void GenerarInforme()
        {
            reportViewerEtiquetas.Owner = this;
            ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            EtiquetasReport informe = new EtiquetasReport();
            ObservableCollection<Lote> lotes = servicioAPI.GetLotes();
            ObservableCollection<LoteInformeEtiquetas> lotesEtiquetas = new ObservableCollection<LoteInformeEtiquetas>();
            foreach (Lote l in lotes)
            {
                for(int i = 0; i < l.LibrosLote.Count; i++)
                {
                    lotesEtiquetas.Add(new LoteInformeEtiquetas(l.IdLote, l.ModalidadLote.Curso));
                }
            }
            informe.SetDataSource(lotesEtiquetas);

            reportViewerEtiquetas.ViewerCore.ReportSource = informe;
        }
    }
}
