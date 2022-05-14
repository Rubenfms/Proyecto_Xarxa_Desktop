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
    ///  Mensajeria para mandar el Alumno actual a la ventana Ver lote y poder consultar que lote tiene a partir del campo idLote de alumno  
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.Messaging.Messages.RequestMessage&lt;Proyecto_Xarxa_Desktop.modelo.Lote&gt;" />
    class VerLoteRequestMessage : RequestMessage<Lote>
    {

    }
}
