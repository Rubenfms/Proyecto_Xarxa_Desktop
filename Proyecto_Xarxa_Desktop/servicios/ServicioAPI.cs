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

/// <summary>
/// Paquete que contiene los servicios
/// </summary>
namespace Proyecto_Xarxa_Desktop.servicios
{
    /// <summary>
    /// Servicio de todo lo referente a las operaciones de la API
    /// </summary>
    class ServicioAPI
    {

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
            catch(JsonSerializationException)
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
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de modalidades", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
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
                var client = new RestClient("http://localhost:8081/apixarxa/xarxa/usuarios");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("x-", "");
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(usuario);
                var body = JsonConvert.SerializeObject(usuario);
                //request.AddParameter("application/json", usuario, ParameterType.RequestBody);
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

            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-", "");
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(alumno);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = Cliente.Execute(request);
            return response.StatusCode;

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

        #endregion
    }
}
