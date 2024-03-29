﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proyecto_Xarxa_Desktop.convertidores
{
    /// <summary>
    /// Convertidor que devuelve true si el usuario no es invitado
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class InvitadoToBoolean : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    return !value.ToString().ToLower().Equals("invitado");
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
