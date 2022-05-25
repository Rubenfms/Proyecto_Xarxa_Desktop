using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de LotesUserControl
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class LotesVM : ObservableObject
    {
        /// <summary>
        /// Lista de lotes que cargamos en la vista
        /// </summary>
        private ObservableCollection<Lote> listaLotes;

        /// <summary>
        /// Gets or sets the lista lotes.
        /// </summary>
        /// <value>
        /// Lista de lotes que cargamos en la vista
        /// </value>
        public ObservableCollection<Lote> ListaLotes
        {
            get { return listaLotes; }
            set { SetProperty(ref listaLotes, value); }
        }

        /// <summary>
        /// El lote seleccionado de la lista de la vista
        /// </summary>
        private Lote loteSeleccionado;

        /// <summary>
        /// Gets or sets the lote seleccionado.
        /// </summary>
        /// <value>
        /// El lote seleccionado de la lista de la vista
        /// </value>
        public Lote LoteSeleccionado
        {
            get { return loteSeleccionado; }
            set { SetProperty(ref loteSeleccionado, value); }
        }

        /// <summary>
        /// El usuario logeado
        /// </summary>
        private Usuario usuarioLogeado;

        /// <summary>
        /// Gets or sets el usuario logeado.
        /// </summary>
        /// <value>
        /// El usuario logeado.
        /// </value>
        public Usuario UsuarioLogeado
        {
            get { return usuarioLogeado; }
            set { SetProperty(ref usuarioLogeado, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private readonly ServicioAPI servicioAPI;

        // Comandos        
        /// <summary>
        /// Gets the generar lote command.
        /// </summary>
        /// <value>
        /// The generar lote command.
        /// </value>
        public RelayCommand GenerarLoteCommand { get; }

        /// <summary>
        /// Gets the eliminar lote command.
        /// </summary>
        /// <value>
        /// The eliminar lote command.
        /// </value>
        public RelayCommand EliminarLoteCommand { get; }

        /// <summary>
        /// Gets the editar lote command.
        /// </summary>
        /// <value>
        /// The editar lote command.
        /// </value>
        public RelayCommand EditarLoteCommand { get; }

        /// <summary>
        /// Gets the asignar lote command.
        /// </summary>
        /// <value>
        /// The asignar lote command.
        /// </value>
        public RelayCommand AsignarLoteCommand { get; }

        /// <summary>
        /// Gets the desasignar lote command.
        /// </summary>
        /// <value>
        /// The desasignar lote command.
        /// </value>
        public RelayCommand DesasignarLoteCommand { get; }

        /// <summary>
        /// Gets the generar cb command.
        /// </summary>
        /// <value>
        /// The generar cb command.
        /// </value>
        public RelayCommand GenerarCBCommand { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="LotesVM"/> class.
        /// </summary>
        public LotesVM()
        {
            UsuarioLogeado = (Usuario)Application.Current.Resources["UsuarioLogeado"];

            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaLotes = servicioAPI.GetLotes();
            LoteSeleccionado = null;

            // Comandos
            GenerarLoteCommand = new RelayCommand(AbrirVistaGenerarLote);
            AsignarLoteCommand = new RelayCommand(AsignarLote);
            DesasignarLoteCommand = new RelayCommand(DesasignarLote);
            EditarLoteCommand = new RelayCommand(EditarLote);
            EliminarLoteCommand = new RelayCommand(EliminarLote);
            GenerarCBCommand = new RelayCommand(GenerarCodigoBarras);

            // Suscripción para mandar el lote a Editar Lote
            WeakReferenceMessenger.Default.Register<LotesVM, EditarLoteRequestMessage>
                (this, (r, m) =>
                {
                    if (!m.HasReceivedResponse) m.Reply(LoteSeleccionado);
                });

            // Suscripción para mandar el lote a Asignar lote
            WeakReferenceMessenger.Default.Register<LotesVM, AsignarLoteRequestMessage>
                (this, (r, m) =>
                {
                    if (!m.HasReceivedResponse) m.Reply(LoteSeleccionado);
                });
        }

        /// <summary>
        /// Abre la vista generar lote.
        /// </summary>
        public void AbrirVistaGenerarLote()
        {
            ServicioNavegacion.AbrirVistaGenerarLote();
        }

        /// <summary>
        /// Abre una vista Asignar lote si el lote seleccionado puede asignarse a algún alumno.
        /// </summary>
        public void AsignarLote()
        {
            // Comprobación de si hay lote seleccionado
            if (LoteSeleccionado == null)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un lote para poder asignarlo", "Necesario Lote Seleccionado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            // Comprobación de que el lote seleccionado no tenga nia asignado
            else if (LoteSeleccionado.NiaAlumno != null)
            {
                ServicioDialogos.ServicioMessageBox($"El lote ya tiene un nia asignado: {LoteSeleccionado.NiaAlumno}", "Lote ya asignado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            else
            {
                ServicioNavegacion.AbrirVistaAsignarLote();
            }

        }

        /// <summary>
        /// Desasigna el lote seleccionado si está asignado a un alumno.
        /// </summary>
        public void DesasignarLote()
        {
            // Comprobación de si hay lote seleccionado
            if (LoteSeleccionado == null)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un lote para poder asignarlo", "Necesario Lote Seleccionado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            // Comprobación de que el lote no tenga ningun nia asignado
            else if (LoteSeleccionado.NiaAlumno == null)
            {
                ServicioDialogos.ServicioMessageBox("El lote no tiene ningún nia asignado", "Nia no asignado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            else
            {
                LoteSeleccionado.NiaAlumno = null;
                HttpStatusCode? statusCode = servicioAPI.PutLote(LoteSeleccionado);
                ServicioDialogos.ServicioMessageBox($"Resultado de la actualización del lote: {statusCode}", "Desasignación lote", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Genera el código de barras del lote.
        /// </summary>
        public void GenerarCodigoBarras()
        {

            if (LoteSeleccionado == null)
            {
                ServicioDialogos.ServicioMessageBox("Tienes que seleccionar un lote primero.", "Selecciona un lote primero", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            else
            {
                new ServicioCodigoBarras().GenerarCB(LoteSeleccionado.IdLote);
                ServicioDialogos.ServicioMessageBox("Codigo de barras creado en C:\\Xarxa", "Código creado", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Abre una vista de Editar Lote
        /// </summary>
        public void EditarLote()
        {
            if (LoteSeleccionado != null) ServicioNavegacion.AbrirVistaEditarLote();
            else ServicioDialogos.ServicioMessageBox("Tienes que seleccionar un lote para poder editarlo.", "Selecciona un lote primero", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        /// <summary>
        /// Elimina el lote seleccionado.
        /// </summary>
        public void EliminarLote()
        {
            if (LoteSeleccionado != null)
            {
                HttpStatusCode? statusCode = servicioAPI.DeleteLote(LoteSeleccionado.IdLote);
                ServicioDialogos.ServicioMessageBox($"Resultado de la eliminación del lote: {statusCode}", "Eliminación lote", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            else ServicioDialogos.ServicioMessageBox("Tienes que seleccionar un lote para poder eliminarlo.", "Selecciona un lote primero", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        /// <summary>
        /// Abre una vista de crear modalidad.
        /// </summary>
        public void AbrirVistaCrearModalidad()
        {
            ServicioNavegacion.AbrirVistaCrearModalidad();
        }
    }
}
