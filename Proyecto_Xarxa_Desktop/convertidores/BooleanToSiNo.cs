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
    /// Convertidor de true o false a Si o No
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class BooleanToSiNo : IValueConverter
    {
        /// <summary>
        /// Recibe los datos del campo PerteneceXarxa y devuelve Si o No dependiendo de si es true o false
        /// </summary>
        /// <param name="value">Valor que recibe (string)</param>
        /// <param name="targetType">El tipo de la propiedad del destino de enlace.</param>
        /// <param name="parameter">Parámetro de convertidor que se va a usar.</param>
        /// <param name="culture">Referencia cultural que se va a usar en el convertidor.</param>
        /// Devuelve "No" si recibe False o "Si" si recibe true
        /// </return>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Equals("False"))
            {
                return "No";
            }
            else if (value.ToString().Equals("True"))
            {
                return "Si";
            }
/*            else if (value.ToString().Equals("Cesion"))
            {
                return "Cesión";
            }*/
            else return "Error";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
