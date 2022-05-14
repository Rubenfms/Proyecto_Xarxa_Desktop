using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.mensajeria
{
    // Mensajeria para establecer comunicacion entre Alumno y Asignar lote

    /// <summary>
    /// Mensajería para establecer comunicación entre Alumno y Asignar Lote.
    /// Manda el lote a la ventana AsignarLoteDialog
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.Messaging.Messages.RequestMessage&lt;Proyecto_Xarxa_Desktop.modelo.Lote&gt;" />
    class AsignarLoteRequestMessage : RequestMessage<Lote>
    {
    }
}
