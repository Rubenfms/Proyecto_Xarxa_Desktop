using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Proyecto_Xarxa_Desktop.convertidores
{

    /// <summary>
    ///   Recibe un valor y si es null devuelve Visibility.Visible y si no es null devuelve Visibility.Collapsed
    /// </summary>
    class NullToVisibilityModificado : IValueConverter
    {

        /// <summary>Convierte un valor null en Visibility.Visible.</summary>
        /// <param name="value">Valor que recibe.</param>
        /// <param name="targetType">El tipo de la propiedad del destino de enlace.</param>
        /// <param name="parameter">Parámetro de convertidor que se va a usar.</param>
        /// <param name="culture">Referencia cultural que se va a usar en el convertidor.</param>
        /// <returns>
        /// Valor convertido.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case null:
                    return Visibility.Visible;
                default:
                    return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
