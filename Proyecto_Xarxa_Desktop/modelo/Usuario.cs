using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    /// <summary>
    /// Clase modelo de los Usuario que acceden a la app
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class Usuario : ObservableObject
    {
        /// <summary>
        /// Nombre del usuario que usa para hacer login
        /// </summary>
        private string nombreUsuario;

        /// <summary>
        /// Gets or sets the nombre usuario.
        /// </summary>
        /// <value>
        /// Nombre del usuario que usa para hacer login
        /// </value>
        [JsonProperty("nombreUsuario")]
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { SetProperty(ref nombreUsuario, value); }
        }

        /// <summary>
        /// Contraseña que usa el usuario para hacer login
        /// </summary>
        private string contrasenya;

        /// <summary>
        /// Gets or sets the contrasenya.
        /// </summary>
        /// <value>
        /// Contraseña que usa el usuario para hacer login
        /// </value>
        [JsonProperty("contrasenya")]
        public string Contrasenya
        {
            get { return contrasenya; }
            set { SetProperty(ref contrasenya, value); }
        }

        /// <summary>
        /// Tipo de usuario que es. Esto definirá su nivel de acceso en la app.
        /// </summary>
        private string tipoUsuario;

        /// <summary>
        /// Gets or sets the tipo usuario.
        /// </summary>
        /// <value>
        /// The tipo usuario.
        /// </value>
        [JsonProperty("tipoUsuario")]
        public string TipoUsuario
        {
            get { return tipoUsuario; }
            set { SetProperty(ref tipoUsuario, value); }
        }

        /// <summary>
        /// Si el usuario esta activo o no
        /// </summary>
        private bool activo;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Usuario"/> is activo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if activo; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("activo")]
        public bool Activo
        {
            get { return activo; }
            set { SetProperty(ref activo, value); }
        }

        /// <summary>
        /// Initializes a new empty instance of the <see cref="Usuario"/> class.
        /// </summary>
        public Usuario() {; }

        public Usuario(string nombreUsuario, string contrasenya)
        {
            NombreUsuario = nombreUsuario;
            Contrasenya = contrasenya;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Usuario"/> class.
        /// </summary>
        /// <param name="nombreUsuario">The nombre usuario.</param>
        /// <param name="contrasenya">The contrasenya.</param>
        /// <param name="tipoUsuario">The tipo usuario.</param>
        public Usuario(string nombreUsuario, string contrasenya, string tipoUsuario)
        {
            NombreUsuario = nombreUsuario;
            Contrasenya = contrasenya;
            TipoUsuario = tipoUsuario;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Usuario"/> class.
        /// </summary>
        /// <param name="nombreUsuario">The nombre usuario.</param>
        /// <param name="contrasenya">The contrasenya.</param>
        /// <param name="tipoUsuario">The tipo usuario.</param>
        /// <param name="activo">if set to <c>true</c> [activo].</param>
        public Usuario(string nombreUsuario, string contrasenya, string tipoUsuario, bool activo)
        {
            NombreUsuario = nombreUsuario;
            Contrasenya = contrasenya;
            TipoUsuario = tipoUsuario;
            Activo = activo;
        }
    }
}
