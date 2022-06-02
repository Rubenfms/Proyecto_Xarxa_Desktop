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
    /// VM de GenerarLote.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class GenerarLoteVM : ObservableObject
    {
        /// <summary>
        /// Lista de modalidades que se muestran en el ComboBox.
        /// </summary>
        private ObservableCollection<Modalidad> listaModalidades;

        /// <summary>
        /// Gets or sets the lista modalidades.
        /// </summary>
        /// <value>
        /// The lista modalidades.
        /// </value>
        public ObservableCollection<Modalidad> ListaModalidades
        {
            get { return listaModalidades; }
            set { SetProperty(ref listaModalidades, value); }
        }

        /// <summary>
        /// Modalidad seleccionada por el usuario en el ComboBox.
        /// </summary>
        private Modalidad modalidadSeleccionada;

        /// <summary>
        /// Gets or sets the modalidad seleccionada.
        /// </summary>
        /// <value>
        /// Modalidad seleccionada por el usuario en el ComboBox.
        /// </value>
        public Modalidad ModalidadSeleccionada
        {
            get { return modalidadSeleccionada; }
            set { SetProperty(ref modalidadSeleccionada, value); }
        }

        /// <summary>
        /// Identificador del lote que se va a generar
        /// </summary>
        private int? idLote;

        /// <summary>
        /// Gets or sets the identifier lote.
        /// </summary>
        /// <value>
        /// Identificador del lote que se va a generar
        /// </value>
        public int? IdLote
        {
            get { return idLote; }
            set { SetProperty(ref idLote, value); }
        }

        private string numeroLotes;

        public string NumeroLotes
        {
            get { return numeroLotes; }
            set { SetProperty(ref numeroLotes, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private ServicioAPI servicioAPI;

        /// <summary>
        /// Gets the confirmar lote command.
        /// </summary>
        /// <value>
        /// The confirmar lote command.
        /// </value>
        public RelayCommand ConfirmarLoteCommand { get; }

        /// <summary>
        /// Gets the limpiar seleccion command.
        /// </summary>
        /// <value>
        /// The limpiar seleccion command.
        /// </value>
        public RelayCommand LimpiarSeleccionCommand { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="GenerarLoteVM"/> class.
        /// </summary>
        public GenerarLoteVM()
        {
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);
            ListaModalidades = servicioAPI.GetModalidades();
            NumeroLotes = "1";

            // Comandos
            LimpiarSeleccionCommand = new RelayCommand(LimpiarSeleccion);
        }

        /// <summary>
        /// Carga las modalidades en la lista de la modalidad que ha seleccionado el usuario.
        /// </summary>
        /// <param name="modalidadSeleccionada">The modalidad seleccionada.</param>
        public void CargarModalidades(string modalidadSeleccionada)
        {
            foreach (Modalidad m in ListaModalidades)
            {
                if (m.Nombre.Equals(modalidadSeleccionada))
                {
                    ModalidadSeleccionada = m;
                }
            }
        }

        /// <summary>
        /// Genera el número del lote actual.
        /// </summary>
        /// <param name="modalidadSeleccionada">The modalidad seleccionada.</param>
        public void GenerarNumeroLote(Modalidad modalidadSeleccionada)
        {
            string curso = ModalidadSeleccionada.Curso.Remove(1, ModalidadSeleccionada.Curso.Length - 1); // Como viene en formato (1ºESO) me quedo solo con el numero

            string cabeceraId = curso + modalidadSeleccionada.Id;
            // Hallamos el idLote
            IdLote = int.Parse(cabeceraId + servicioAPI.GetNextIdLote(int.Parse(cabeceraId)).ToString().PadLeft(3, '0'));
        }

        /// <summary>
        /// Limpia la modalidad seleccionada y el idlote.
        /// </summary>
        public void LimpiarSeleccion()
        {
            ModalidadSeleccionada = null;
            IdLote = null;
        }

        /// <summary>
        /// Añade el nuevo lote.
        /// </summary>
        public bool ConfirmarLote()
        {
            int numero;
            if (ModalidadSeleccionada != null)
            {
                if (int.TryParse(NumeroLotes, out numero))
                {
                    for (int i = 0; i < numero; i++)
                    {
                        Lote nuevolote = new Lote((int)IdLote, ModalidadSeleccionada);
                        HttpStatusCode? statusCode = servicioAPI.PostLote(nuevolote);

                        string curso = ModalidadSeleccionada.Curso.Remove(1, ModalidadSeleccionada.Curso.Length - 1);
                        string cabeceraId = curso + modalidadSeleccionada.Id;
                        IdLote = int.Parse(cabeceraId + servicioAPI.GetNextIdLote(int.Parse(cabeceraId)).ToString().PadLeft(3, '0'));

                        WeakReferenceMessenger.Default.Send(new DatoAñadidoOModificadoMessage(true));

                        if (statusCode != HttpStatusCode.Created)
                        {
                            ServicioDialogos.ServicioMessageBox($"Resultado del alta del lote: {statusCode}", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }
                    }
                    ServicioDialogos.ServicioMessageBox($"{numero} lotes dados de alta", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else if (numero < 1)
                {
                    ServicioDialogos.ServicioMessageBox($"Introduce un numero correcto de lotes", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else
                {
                    ServicioDialogos.ServicioMessageBox($"Introduce un numero en el recuadro", "Resultado alta", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }
            else return false;
        }
    }
}
