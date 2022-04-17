﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
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

        private static ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();

        // Método que devuelve todos los lotes
        public ObservableCollection<Lote> GetLotes()
        {
            try
            {
                ObservableCollection<Lote> result = new ObservableCollection<Lote>();

                RestRequest peticion = new RestRequest("/xarxa/lotes", Method.Get);

                var response = Cliente.GetAsync(peticion);

                result = JsonConvert.DeserializeObject<ObservableCollection<Lote>>(response.Result.Content);

                return result;
            }
            catch (AggregateException)
            {
                ServicioDialogos.ServicioMessageBox("La API ha tenido un error recuperando la lista de lotes", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
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

        public static ObservableCollection<Usuario> GetUsuarios()
        {
            var url = Properties.Settings.Default.CadenaConexionLocalhost + "/xarxa/usuarios";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            listaUsuarios = JsonConvert.DeserializeObject<ObservableCollection<Usuario>>(responseBody);
                            return listaUsuarios;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
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
                ServicioDialogos.ServicioMessageBox("Error con la API", "Error con la API", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
                throw;
            }
        }
    }
}
