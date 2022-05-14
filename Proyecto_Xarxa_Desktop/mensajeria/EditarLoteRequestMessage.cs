using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.mensajeria
{
    /// <summary>
    /// Mensajeria para establecer comunicacion entre Lote y EditarLote
    /// Manda el lote seleccionado al diálogo EditarLote
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.Messaging.Messages.RequestMessage&lt;Proyecto_Xarxa_Desktop.modelo.Lote&gt;" />
    class EditarLoteRequestMessage : RequestMessage<Lote>
    {

    }
    
}
