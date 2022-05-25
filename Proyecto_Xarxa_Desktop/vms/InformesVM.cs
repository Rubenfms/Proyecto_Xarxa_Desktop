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
    /// <summary>
    /// VM de InformesUserControl
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class InformesVM : ObservableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformesVM"/> class.
        /// </summary>
        public InformesVM()
        {
            XarxaCompletoReportCommand = new RelayCommand(InformeXarxaCompleto);
            ConcesionReportCommand = new RelayCommand(InformeConcesion);
            GruposXarxaReportCommand = new RelayCommand(InformeXarxaGrupos);
            RecogidaReportCommand = new RelayCommand(InformeRecogida);
            LotesReportCommand = new RelayCommand(InformeLotes);
            EtiquetasReportCommand = new RelayCommand(InformeEtiquetas);
            EtiquetasBolsaReportCommand = new RelayCommand(InformeEtiquetasBolsa);
        }

        /// <summary>
        /// Gets the xarxa completo report command.
        /// </summary>
        /// <value>
        /// The xarxa completo report command.
        /// </value>
        public RelayCommand XarxaCompletoReportCommand { get; }

        /// <summary>
        /// Gets the concesion report command.
        /// </summary>
        /// <value>
        /// The concesion report command.
        /// </value>
        public RelayCommand ConcesionReportCommand { get; }

        /// <summary>
        /// Gets the grupos xarxa report command.
        /// </summary>
        /// <value>
        /// The grupos xarxa report command.
        /// </value>
        public RelayCommand GruposXarxaReportCommand { get; }

        /// <summary>
        /// Gets the recogida report command.
        /// </summary>
        /// <value>
        /// The recogida report command.
        /// </value>
        public RelayCommand RecogidaReportCommand { get; }

        /// <summary>
        /// Gets the lotes report command.
        /// </summary>
        /// <value>
        /// The lotes report command.
        /// </value>
        public RelayCommand LotesReportCommand { get; }

        /// <summary>
        /// Gets the etiquetas report command.
        /// </summary>
        /// <value>
        /// The etiquetas report command.
        /// </value>
        public RelayCommand EtiquetasReportCommand { get; }

        /// <summary>
        /// Gets the etiquetas bolsa report command.
        /// </summary>
        /// <value>
        /// The etiquetas bolsa report command.
        /// </value>
        public RelayCommand EtiquetasBolsaReportCommand { get; }


        /// <summary>
        /// Abre un informe xarxa completo.
        /// </summary>
        private void InformeXarxaCompleto() => ServicioNavegacion.AbrirInformeXarxaCompleto();

        /// <summary>
        /// Abre un informe concesion.
        /// </summary>
        private void InformeConcesion() => ServicioNavegacion.AbrirInformeConcesion();

        /// <summary>
        /// Abre un informe xarxa grupos.
        /// </summary>
        private void InformeXarxaGrupos() => ServicioNavegacion.AbrirInformeXarxaGrupos();

        /// <summary>
        /// Abre un informe recogida.
        /// </summary>
        private void InformeRecogida() => ServicioNavegacion.AbrirInformeRecogida();

        /// <summary>
        /// Abre un informe lotes.
        /// </summary>
        private void InformeLotes() => ServicioNavegacion.AbrirInformeLotes();

        /// <summary>
        /// Abre un informe etiquetas.
        /// </summary>
        private void InformeEtiquetas() => ServicioNavegacion.AbrirInformeEtiquetas();

        /// <summary>
        /// Abre un informe etiquetas bolsa.
        /// </summary>
        private void InformeEtiquetasBolsa() => ServicioNavegacion.AbrirInformeEtiquetasBolsa();






    }
}
