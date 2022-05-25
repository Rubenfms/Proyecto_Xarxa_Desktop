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
        /// <summary>
        /// Contenido del número
        /// </summary>
        long contenido;

        /// <summary>
        /// Gets or sets the contenido.
        /// </summary>
        /// <value>
        /// Contenido del número
        /// </value>
        [JsonProperty("numero")]
        public long Contenido
        {
            get { return contenido; }
            set { SetProperty(ref contenido, value); }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Numero"/> class.
        /// </summary>
        /// <param name="contenido">The contenido.</param>
        public Numero(long contenido)
        {
            Contenido = contenido;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Numero"/> class.
        /// </summary>
        public Numero()
        {
        }
    }
}
