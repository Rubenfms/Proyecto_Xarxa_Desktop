using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Proyecto_Xarxa_Desktop.modelo
{
    class LibroXarxa:Libro
    {
        public LibroXarxa(int codigoXarxa, string isbn, string titulo, string curso, string departamento, string editorial) : base(isbn, titulo, curso, departamento, editorial)
        {
            CodigoXarxa = codigoXarxa;
        }

        private int _codigoXarxa;

        public int CodigoXarxa
        {
            get { return _codigoXarxa; }
            set { SetProperty(ref _codigoXarxa, value); }
        }

    }
}
