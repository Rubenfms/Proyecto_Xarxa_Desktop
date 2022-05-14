using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.informes;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vistasInformes;
using SAPBusinessObjects.WPF.Viewer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class InformesVM : ObservableObject
    {
        public InformesVM()
        {
            XarxaCompletoReportCommand = new RelayCommand(InformeXarxaCompleto);
            ConcesionReportCommand = new RelayCommand(InformeConcesion);
            GruposXarxaReportCommand = new RelayCommand(InformeXarxaGrupos);
            RecogidaReportCommand = new RelayCommand(InformeRecogida);
        }

        public RelayCommand XarxaCompletoReportCommand { get; }
        public RelayCommand ConcesionReportCommand { get; }
        public RelayCommand GruposXarxaReportCommand { get; }
        public RelayCommand RecogidaReportCommand { get; }
        public RelayCommand LotesReportCommand { get; }
        public RelayCommand EtiquetasReportCommand { get; }
        public RelayCommand EtiquetasBolsaReportCommand { get; }

        private void InformeXarxaCompleto() => ServicioNavegacion.AbrirInformeXarxaCompleto();
        private void InformeConcesion() => ServicioNavegacion.AbrirInformeConcesion();
        private void InformeXarxaGrupos() => ServicioNavegacion.AbrirInformeXarxaGrupos();
        private void InformeRecogida() => ServicioNavegacion.AbrirInformeRecogida();





    }
}
