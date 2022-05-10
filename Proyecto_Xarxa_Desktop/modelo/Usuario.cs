using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
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

        [JsonProperty("nombreUsuario")]
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { SetProperty(ref nombreUsuario, value); }
        }

        private string contrasenya;

        [JsonProperty("contrasenya")]
        public string Contrasenya
        {
            get { return contrasenya; }
            set { SetProperty(ref contrasenya, value); }
        }

        private string tipoUsuario;

        [JsonProperty("tipoUsuario")]
        public string TipoUsuario
        {
            get { return tipoUsuario; }
            set { SetProperty(ref tipoUsuario, value); }
        }

        private bool activo;

        [JsonProperty("activo")]
        public bool Activo
        {
            get { return activo; }
            set { SetProperty(ref activo, value); }
        }

        public Usuario() {; }

        public Usuario(string nombreUsuario, string contrasenya, string tipoUsuario)
        {
            NombreUsuario = nombreUsuario;
            Contrasenya = contrasenya;
            TipoUsuario = tipoUsuario;
        }
        public Usuario(string nombreUsuario, string contrasenya, string tipoUsuario, bool activo)
        {
            NombreUsuario = nombreUsuario;
            Contrasenya = contrasenya;
            TipoUsuario = tipoUsuario;
            Activo = activo;
        }
    }
}
