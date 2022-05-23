using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Proyecto_Xarxa_Desktop.modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Sockets;
using RestSharp.Serializers;

namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Servicio de todo lo referente a las operaciones de la API
    /// </summary>
    class ServicioAPI
    {

        public const string COOKIE_SESSION = "JSESSIONID";

        private RestClient cliente;

        public RestClient Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioAPI"/> class.
        /// </summary>
        /// <param name="cadenaConexion">Cadena de conexión a la API.</param>
        public ServicioAPI(string cadenaConexion)
        {
            Cliente = new RestClient(cadenaConexion);
        }

        public string GetSessionId()
        {
           return System.Windows.Application.Current.Resources["sessionId"] != null 
                ? System.Windows.Application.Current.Resources["sessionId"].ToString() : "";
        }

        #region Métodos Auth

        public string LoginUsuario(string nombreUsuario, string contrasenya)
        {
            string sessionId = "";
            var request = new RestRequest("/xarxa/auth/login", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            Usuario u = new Usuario(nombreUsuario, contrasenya);
            var body = JsonConvert.SerializeObject(u);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            if (response.Cookies != null && response.Cookies.Count > 0)
            {
                sessionId = response.Cookies[0].Value;
            }
            return sessionId;
        }

        #endregion

        #region Métodos Lotes   
        /// <summary>
        /// Método que devuelve todos los lotes     
        /// </summary>
        /// <returns>
        /// Devuelve una nueva lista de lotes o null
        /// </returns>
        public ObservableCollection<Lote> GetLotes()
        {
            try
            {
                ObservableCollection<Lote> result = new ObservableCollection<Lote>();

                RestRequest peticion = new RestRequest("/xarxa/lotes", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.ExecuteGetAsync(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Lote>>(response.Result.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de lotes", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de lotes", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Método que devuelve un lote a partir de su id
        /// </summary>
        /// <param name="id">Identificador del lote que queremos obtener.</param>
        /// <returns>
        /// Devuelve un objeto Lote
        /// </returns>
        public Lote GetLote(int? id)
        {
            try
            {
                Lote result = new Lote();

                RestRequest peticion = new RestRequest($"/xarxa/lotes/{id}", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.ExecuteGetAsync(peticion);

                result = JsonConvert.DeserializeObject<Lote>(response.Result.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando lote", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando lote", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (JsonSerializationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que actualiza un lote    
        /// </summary>
        /// <param name="lote">Lote a actualizar.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API
        /// </returns>
        public HttpStatusCode? PutLote(Lote lote)
        {
            var request = new RestRequest("/xarxa/lotes", Method.PUT);
            request.AddCookie(COOKIE_SESSION, GetSessionId());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-", "");
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(lote);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            return response.StatusCode;

        }

        /// <summary>
        /// Método que elimina un lote a partir de su id        
        /// </summary>
        /// <param name="id">Identificador del lote a eliminar.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API
        /// </returns>
        public HttpStatusCode? DeleteLote(int id)
        {
            var request = new RestRequest($"/xarxa/lotes/{id}", Method.DELETE);
            request.AddCookie(COOKIE_SESSION, GetSessionId());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-", "");
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            return response.StatusCode;

        }

        #endregion

        #region Métodos Modalidades
        /// <summary>
        /// Método que devuelve todas las modalidades
        /// </summary>
        /// <returns>
        /// Devuelve una lista de modalidades
        /// </returns>
        public ObservableCollection<Modalidad> GetModalidades()
        {
            try
            {
                ObservableCollection<Modalidad> result = new ObservableCollection<Modalidad>();

                RestRequest peticion = new RestRequest("/xarxa/modalidades", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.Execute(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Modalidad>>(response.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de modalidades", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de lotes", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        #endregion

        #region Métodos Usuarios
        /// <summary>
        /// Método que devuelve un usuario a partir de un nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario del usuario que queremos.</param>
        /// <returns>
        /// Devuelve un objeto Usuario o null
        /// </returns>
        public Usuario GetUsuario(String username)
        {
            try
            {
                Usuario result = new Usuario();

                RestRequest peticion = new RestRequest($"/xarxa/usuarios/{username}", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.Execute(peticion);

                result = JsonConvert.DeserializeObject<Usuario>(response.Content);
                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API al autenticar al usuario", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando el usuario", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch(Exception)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error inesperado", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Método que añade un usuario        
        /// </summary>
        /// <param name="usuario">Usuario a añadir.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API
        /// </returns>
        public HttpStatusCode? PostUsuario(Usuario usuario)
        {
            try
            {
                RestRequest request = new RestRequest("/xarxa/usuarios", Method.POST);
                request.AddCookie(COOKIE_SESSION, GetSessionId());
                request.AddHeader("Accept", "application/json");
                request.AddHeader("x-", "");
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(usuario);
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = Cliente.Execute(request);
                return response.StatusCode;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API al autenticar al usuario", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene una lista de usuarios.
        /// </summary>
        /// <returns>Devuelve la lista de usuarios</returns>
        public ObservableCollection<Usuario> GetUsuarios()
        {
            try
            {
                ObservableCollection<Usuario> result = new ObservableCollection<Usuario>();

                RestRequest peticion = new RestRequest("/xarxa/usuarios", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.Execute(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Usuario>>(response.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de usuarios", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de usuarios", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Método que actualiza el usuario.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns> Devuelve un status code que varía en función del resultado de la operación de la API. </returns>
        public HttpStatusCode? PutUsuario(Usuario usuario)
        {
            var request = new RestRequest("/xarxa/usuarios", Method.PUT);
            request.AddCookie(COOKIE_SESSION, GetSessionId());


            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-", "");
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(usuario);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            return response.StatusCode;

        }
        #endregion

        #region Métodos Alumnos
        /// <summary>
        /// Método que devuelve todos los alumnos        
        /// </summary>
        /// <returns>
        /// Devuelve una nueva lista de alumnos
        /// </returns>
        public ObservableCollection<Alumno> GetAlumnos()
        {
            try
            {
                ObservableCollection<Alumno> result = new ObservableCollection<Alumno>();

                RestRequest peticion = new RestRequest("/xarxa/alumnos", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.Execute(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Alumno>>(response.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de alumnos", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de alumnos", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Devuelve un alumno a partir de un NIA
        /// </summary>
        /// <param name="nia">NIA del alumno que queremos.</param>
        /// <returns>
        /// Devuelve un objeto Alumno
        /// </returns>
        public Alumno GetAlumno(int? nia)
        {
            try
            {
                Alumno result = new Alumno();

                RestRequest peticion = new RestRequest($"/xarxa/alumnos/{nia}", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.Execute(peticion);

                result = JsonConvert.DeserializeObject<Alumno>(response.Content);
                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Método que actualiza un alumno.
        /// </summary>
        /// <param name="alumno">Alumno a actualizar.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API
        /// </returns>
        public HttpStatusCode? PutAlumno(Alumno alumno)
        {
            var request = new RestRequest("/xarxa/alumnos", Method.PUT);
            request.AddCookie(COOKIE_SESSION, GetSessionId());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-", "");
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(alumno);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            return response.StatusCode;

        }

        /// <summary>
        /// Método que añade un alumno        
        /// </summary>
        /// <param name="usuario">Alumno a añadir.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API
        /// </returns>
        public HttpStatusCode? PostAlumno(Alumno alumno)
        {
            try
            {
                RestRequest request = new RestRequest("/xarxa/alumnos", Method.POST);
                request.AddCookie(COOKIE_SESSION, GetSessionId());
                request.AddHeader("Accept", "application/json");
                request.AddHeader("x-", "");
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(alumno);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = Cliente.Execute(request);
                return response.StatusCode;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API al introducir el alumno", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Añade una lista de alumnos.
        /// </summary>
        /// <param name="listaAlumnos">La lista de alumnos a añadir.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API
        /// </returns>
        public HttpStatusCode? PostAlumnos(ObservableCollection<Alumno> listaAlumnos)
        {
            try
            {
                RestRequest request = new RestRequest("/xarxa/alumnos/addLista", Method.POST);
                request.AddCookie(COOKIE_SESSION, GetSessionId());
                request.AddHeader("Accept", "application/json");
                request.AddHeader("x-", "");
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json; 
                var body = JsonConvert.SerializeObject(listaAlumnos);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = Cliente.Execute(request);
                return response.StatusCode;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API al introducir el alumno", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }
        #endregion

        #region Métodos Libros
        /// <summary>
        /// Método que devuelve todos los libros    
        /// </summary>
        /// <returns>
        /// Devuelve una lista de libros
        /// </returns>
        public ObservableCollection<Libro> GetLibros()
        {
            try
            {
                ObservableCollection<Libro> result = new ObservableCollection<Libro>();

                RestRequest peticion = new RestRequest("/xarxa/libros", Method.GET);
                peticion.AddCookie(COOKIE_SESSION, GetSessionId());

                var response = Cliente.Execute(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(response.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de libros", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
            catch (ArgumentNullException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de libros", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Método que añade un libro.        
        /// </summary>
        /// <param name="libro">Libro a añadir.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API.
        /// </returns>
        public HttpStatusCode? PostLibro(Libro libro)
        {
            try
            {
                RestRequest request = new RestRequest("/xarxa/libros", Method.POST);
                request.AddCookie(COOKIE_SESSION, GetSessionId());
                request.AddHeader("Accept", "application/json");
                request.AddHeader("x-", "");
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(libro);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = Cliente.Execute(request);
                return response.StatusCode;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API al introducir el libro", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        /// <summary>
        /// Método que actualiza un libro.
        /// </summary>
        /// <param name="libro">El libro a actualizar.</param>
        /// <returns> Devuelve un status code que varía en función del resultado de la operación de la API. </returns>
        public HttpStatusCode? PutLibro(Libro libro)
        {
            var request = new RestRequest("/xarxa/libros", Method.PUT);
            request.AddCookie(COOKIE_SESSION, GetSessionId());


            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-", "");
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(libro);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            return response.StatusCode;

        }

        /// <summary>
        /// Método que elimina un libro a partir de su ibsn      
        /// </summary>
        /// <param name="isbn">ISBN del libro a eliminar.</param>
        /// <returns>
        /// Devuelve un status code que varía en función del resultado de la operación de la API
        /// </returns>
        public HttpStatusCode? DeleteLibro(string isbn)
        {
            var request = new RestRequest($"/xarxa/libros/{isbn}", Method.DELETE);
            request.AddCookie(COOKIE_SESSION, GetSessionId());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-", "");
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            return response.StatusCode;

        }

        #endregion
    }
}
