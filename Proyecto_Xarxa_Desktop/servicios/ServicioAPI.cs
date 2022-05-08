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
    class ServicioAPI
    {
        private RestClient cliente;

        public RestClient Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public ServicioAPI(string cadenaConexion)
        {
            Cliente = new RestClient(cadenaConexion);
        }

        #region Métodos Lotes
        // Método que devuelve todos los lotes
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

        // Método que devuelve un lote a partir de su id
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
        }

        // Método que actualiza un lote
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
        #endregion

        #region Métodos Modalidades
        // Método que devuelve todas las modalidades
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
        // Método que recibe un nombre de usuario y hace una petición a /xarxa/usuarios/nombre
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

        // Método que añade un usuario
        public HttpStatusCode? PostUsuario(Usuario usuario)
        {
            try
            {
                RestRequest peticion = new RestRequest($"/xarxa/usuarios", Method.POST);

                /*                var json = JsonConvert.SerializeObject(usuario); */
                peticion.RequestFormat = DataFormat.Json;

                peticion.AddJsonBody(usuario);

                var response = Cliente.ExecutePostAsync(peticion);

                return response.Result.StatusCode;
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
        // Método que devuelve todos los alumnos
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

        // Método que devuelve un alumno a partir de su NIA
        public Alumno GetAlumno(int nia)
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

        #endregion

        #region Métodos Libros
        // Método que devuelve todos los libros
        // Método que devuelve todos los alumnos
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
