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
    /// Mensajería para mandar el libro añadido a la lista de libros de la nueva modalidad
    /// </summary>
    class AnyadirLibroAModalidadMessage : ValueChangedMessage<Libro>
    {
        /// <summary>
        /// Mensajería para mandar el libro añadido a la lista de libros de la nueva modalidad
        /// </summary>
        /// <param name="libro">The libro.</param>
        public AnyadirLibroAModalidadMessage(Libro libro) : base(libro) { }
    }
}
