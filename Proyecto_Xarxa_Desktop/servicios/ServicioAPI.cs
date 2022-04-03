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

        private static ObservableCollection<Lote> listaLotes = new ObservableCollection<Lote>();
        private static ObservableCollection<Modalidad> listaModalidades = new ObservableCollection<Modalidad>();
        private static ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();
        public static ObservableCollection<Lote> GetLotes()
        {
            var url = Properties.Settings.Default.CadenaConexionLocalhost + "/xarxa/lotes";
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
                            // Revisar, string contiene idModalidad y XarxaCollection
                            // Clase Lote tiene objeto Modalidad
                            listaLotes = JsonConvert.DeserializeObject<ObservableCollection<Lote>>(responseBody);
                            return listaLotes;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public static ObservableCollection<Modalidad> GetModalidades()
        {
            var url = Properties.Settings.Default.CadenaConexionLocalhost + "/xarxa/modalidades";
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
                            listaModalidades = JsonConvert.DeserializeObject<ObservableCollection<Modalidad>>(responseBody);
                            return listaModalidades;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
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
            Usuario result = new Usuario();

            RestRequest peticion = new RestRequest($"/xarxa/usuarios/{username}", Method.Get);

            var response = Cliente.GetAsync(peticion);

            result = JsonConvert.DeserializeObject<Usuario>(response.Result.Content); 
            return result;
        }
    }
}
