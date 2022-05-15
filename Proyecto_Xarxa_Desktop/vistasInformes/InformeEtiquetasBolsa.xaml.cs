using Proyecto_Xarxa_Desktop.informes;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System.Collections.ObjectModel;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vistasInformes
{
    public partial class InformeEtiquetasBolsa : Window
    {
        public InformeEtiquetasBolsa()
        {
            InitializeComponent();
            GenerarInforme();
        }

        private void GenerarInforme()
        {
            reportViewerEtiquetasBolsa.Owner = this;
            ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            EtiquetasBolsaReport informe = new EtiquetasBolsaReport();
            ObservableCollection<Lote> lotes = servicioAPI.GetLotes();
            ObservableCollection<LoteInformeEtiquetas> lotesEtiquetas = new ObservableCollection<LoteInformeEtiquetas>();
            foreach (Lote l in lotes)
            {
                if (l.NiaAlumno != null || l.NiaAlumno == 0)
                {
                    Alumno a = servicioAPI.GetAlumno(l.NiaAlumno);
                    lotesEtiquetas.Add(new LoteInformeEtiquetas(l.IdLote, l.ModalidadLote.Curso, a.Nombre + " " + a.Apellido1));
                }
            }
            informe.SetDataSource(lotesEtiquetas);

            reportViewerEtiquetasBolsa.ViewerCore.ReportSource = informe;
        }
    }
}
