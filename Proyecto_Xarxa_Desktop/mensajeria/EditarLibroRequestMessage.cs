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
    /// Mensajería para mandar el libro seleccionado de la pantalla Libro a EditarLibroDialog
    /// </summary>
    class EditarLibroRequestMessage : RequestMessage<Libro>
    {
    }
}
