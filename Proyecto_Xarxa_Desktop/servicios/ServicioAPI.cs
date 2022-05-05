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

        // Método que devuelve todos los lotes
        public ObservableCollection<Lote> GetLotes()
        {
            ObservableCollection<Lote> result = new ObservableCollection<Lote>();

            RestRequest peticion = new RestRequest("/xarxa/lotes", Method.Get);

            var response = Cliente.ExecuteGetAsync(peticion);

            result = JsonConvert.DeserializeObject<ObservableCollection<Lote>>(response.Result.Content);

            return result;
        }

        // Método que devuelve todas las modalidades
        public ObservableCollection<Modalidad> GetModalidades()
        {
            try
            {
                ObservableCollection<Modalidad> result = new ObservableCollection<Modalidad>();

                RestRequest peticion = new RestRequest("/xarxa/modalidades", Method.Get);

                var response = Cliente.GetAsync(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Modalidad>>(response.Result.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de modalidades", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        // Método que recibe un nombre de usuario y hace una petición a /xarxa/usuarios/nombre
        public Usuario GetUsuario(String username)
        {
            try
            {
                Usuario result = new Usuario();

                RestRequest peticion = new RestRequest($"/xarxa/usuarios/{username}", Method.Get);

                var response = Cliente.GetAsync(peticion);

                result = JsonConvert.DeserializeObject<Usuario>(response.Result.Content);
                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API al autenticar al usuario", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }

        // Método que añade un usuario
        public HttpStatusCode? PostUsuario(Usuario usuario)
        {
            try
            {
                Usuario result = new Usuario();

                RestRequest peticion = new RestRequest($"/xarxa/usuarios", Method.Post);

                var json = JsonConvert.SerializeObject(usuario);

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
        // Método que devuelve todos los alumnos
        public ObservableCollection<Alumno> GetAlumnos()
        {
            try
            {
                ObservableCollection<Alumno> result = new ObservableCollection<Alumno>();

                RestRequest peticion = new RestRequest("/xarxa/alumnos", Method.Get);

                var response = Cliente.GetAsync(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Alumno>>(response.Result.Content);

                return result;
            }
            catch (AggregateException)
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

                RestRequest peticion = new RestRequest($"/xarxa/alumnos/{nia}", Method.Get);

                var response = Cliente.GetAsync(peticion);

                result = JsonConvert.DeserializeObject<Alumno>(response.Result.Content);
                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("Error con la API", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }
    }
}
