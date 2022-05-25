using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.mensajeria
{

    /// <summary>
    /// Mensajería para mandar el libro añadido a la lista de libros de la nueva modalidad
    /// </summary>
    public class DatoAñadidoOModificadoMessage : ValueChangedMessage<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatoAñadidoOModificadoMessage"/> class.
        /// </summary>
        /// <param name="cambios">if set to <c>true</c> [cambios].</param>
        public DatoAñadidoOModificadoMessage(bool cambios) : base(cambios) { }
    }
}
