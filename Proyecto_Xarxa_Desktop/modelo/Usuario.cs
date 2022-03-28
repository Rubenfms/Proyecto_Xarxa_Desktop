using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    class Usuario : ObservableObject
    {
        private string nombreUsuario;

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { SetProperty(ref nombreUsuario, value); }
        }

        private string contrasenya;

        public string Contrasenya
        {
            get { return contrasenya; }
            set { SetProperty(ref contrasenya, value); }
        }

        public Usuario() {; }

        public Usuario(string nombreUsuario, string contrasenya)
        {
            NombreUsuario = nombreUsuario;
            Contrasenya = contrasenya;
        }
    }
}
