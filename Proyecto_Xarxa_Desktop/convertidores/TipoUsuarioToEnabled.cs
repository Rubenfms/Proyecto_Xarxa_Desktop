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
    ///     Convertidor que devuelve true o false dependiendo si puede ver las opciones de super usuario
    /// </summary>
    class TipoUsuarioToEnabled : IValueConverter
    {

        /// <summary>Convierte tipoUsuario (string) a boolean</summary>
        /// <param name="value">Valor generado por el origen de enlace.</param>
        /// <param name="targetType">El tipo de la propiedad del destino de enlace.</param>
        /// <param name="parameter">Parámetro de convertidor que se va a usar.</param>
        /// <param name="culture">Referencia cultural que se va a usar en el convertidor.</param>
        /// <returns>
        /// Valor convertido (booleano)
        /// Si el método devuelve <span class="keyword"><span class="languageSpecificText"><span class="cs">null</span><span class="vb">Nothing</span><span class="cpp">nullptr</span></span></span><span class="nu">a null reference (<span class="keyword">Nothing</span> in Visual Basic)</span>, se usa el valor nulo válido.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    return value.ToString().ToLower().Equals("superadmin") ? true : false;
                }
                else
                {
                    return false;
                }

            }
            catch (NullReferenceException)
            {
                return false;
            }
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
