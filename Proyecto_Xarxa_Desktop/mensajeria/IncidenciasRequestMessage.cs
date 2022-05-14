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
    /// Mensajeria para mandar el alumno (para ver sus incidencias) de la pantalla de alumnos a VerIncidencias
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.Messaging.Messages.RequestMessage&lt;Proyecto_Xarxa_Desktop.modelo.Alumno&gt;" />
    class IncidenciasRequestMessage : RequestMessage<Alumno>
    {
    }
}
