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

namespace Proyecto_Xarxa_Desktop.servicios
{
    class ServicioAPI
    {
        private static ObservableCollection<Lote> listaLotes = new ObservableCollection<Lote>();
        public static ObservableCollection<Lote> GetLotes()
        {
            var url = $"http://localhost:8081/apixarxa/xarxa/lotes";
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
    }
}
