using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.mensajeria
{
    public class DatoAñadidoOModificadoMessage : ValueChangedMessage<bool>
    {
        public DatoAñadidoOModificadoMessage(bool cambios) : base(cambios) { }
    }
}
