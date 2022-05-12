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

    class AsignarLoteRequestMessage : RequestMessage<Lote>
    {
    }
}
