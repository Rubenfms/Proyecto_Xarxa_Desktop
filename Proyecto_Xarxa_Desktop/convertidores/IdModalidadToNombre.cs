using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proyecto_Xarxa_Desktop.convertidores
{
    class IdModalidadToNombre : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int idModalidad = (int)value;

            foreach(Modalidad m in ServicioCargarDatos.ListaModalidades)
            {
                if (m.Id == idModalidad) return m.Nombre;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
