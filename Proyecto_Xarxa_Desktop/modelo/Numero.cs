using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Proyecto_Xarxa_Desktop.modelo
{
    class Numero : ObservableObject
    {
        long contenido;

        [JsonProperty("numero")]
        public long Contenido
        {
            get { return contenido; }
            set { SetProperty(ref contenido, value); }
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public Numero(long contenido)
        {
            Contenido = contenido;
        }

        public Numero()
        {
        }
    }
}
