using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de EditarLote.xaml
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableRecipient" />
    class EditarLoteVM : ObservableRecipient
    {
        /// <summary>
        /// El lote que vamos a editar.
        /// </summary>
        private Lote lote;

        /// <summary>
        /// Gets or sets the lote.
        /// </summary>
        /// <value>
        /// El lote que vamos a editar.
        /// </value>
        public Lote Lote
        {
            get { return lote; }
            set { SetProperty(ref lote, value); }
        }

        // Comandos        
        /// <summary>
        /// Gets the anyadir libro command.
        /// </summary>
        /// <value>
        /// The anyadir libro command.
        /// </value>
        public RelayCommand AnyadirLibroCommand { get; }

        /// <summary>
        /// Gets the eliminar libro command.
        /// </summary>
        /// <value>
        /// The eliminar libro command.
        /// </value>
        public RelayCommand EliminarLibroCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditarLoteVM"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor will produce an instance that will use the <see cref="P:Microsoft.Toolkit.Mvvm.Messaging.WeakReferenceMessenger.Default" /> instance
        /// to perform requested operations. It will also be available locally through the <see cref="P:Microsoft.Toolkit.Mvvm.ComponentModel.ObservableRecipient.Messenger" /> property.
        /// </remarks>
        public EditarLoteVM()
        {
            // Recibimos el lote seleccionado de la vista de todos los lotes
            try
            {
                Lote = WeakReferenceMessenger.Default.Send<EditarLoteRequestMessage>();
            }
            catch (InvalidOperationException)
            {
                Lote = null;
            }
        }
    }
}
