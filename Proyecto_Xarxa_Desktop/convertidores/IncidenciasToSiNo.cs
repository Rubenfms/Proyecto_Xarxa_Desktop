using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proyecto_Xarxa_Desktop.convertidores
{

    /// <summary>
    ///   Convertidor que muestra en la pantalla de alumnos si el alumno tiene incidencias o no
    /// </summary>
    class IncidenciasToSiNo : IValueConverter
    {

        /// <summary>Convierte si no tiene incidencias ("") en No y si tiene incidencias en Si.</summary>
        /// <param name="value">Valor que recibe (string).</param>
        /// <param name="targetType">El tipo de la propiedad del destino de enlace.</param>
        /// <param name="parameter">Parámetro de convertidor que se va a usar.</param>
        /// <param name="culture">Referencia cultural que se va a usar en el convertidor.</param>
        /// <returns>
        /// Valor convertido (string) Si o No.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value.ToString().Equals("") || value == null) return "No"; else return "Si";
            }
            catch (NullReferenceException)
            {
                return "No";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
