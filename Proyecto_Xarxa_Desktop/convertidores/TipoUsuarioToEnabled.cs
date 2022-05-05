using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proyecto_Xarxa_Desktop.convertidores
{
    // Convertidor que devuelve true o false dependiendo si puede ver las opciones de super usuario
    class TipoUsuarioToEnabled : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value.ToString().ToLower().Equals("superadmin");
        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
