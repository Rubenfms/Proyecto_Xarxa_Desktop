﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    class Libro:ObservableObject
    {

        public Libro(string isbn, string titulo, string curso, string departamento, string editorial)
        {
            Isbn = isbn;
            Titulo = titulo;
            Curso = curso;
            Departamento = departamento;
            Editorial = editorial;
        }

        private string _isbn;

        [JsonProperty("isbnLibro")]
        public string Isbn
        {
            get { return _isbn; }
            set { SetProperty(ref _isbn, value); }
        }

        private string _titulo;

        [JsonProperty("titulo")]
        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }

        private string _curso;

        [JsonProperty("curso")]
        public string Curso
        {
            get { return _curso; }
            set { SetProperty(ref _curso, value); }
        }

        private string _departamento;

        [JsonProperty("departamento")]
        public string Departamento
        {
            get { return _departamento; }
            set { SetProperty(ref _departamento, value); }
        }

        private string _editorial;

        [JsonProperty("editorial")]
        public string Editorial
        {
            get { return _editorial; }
            set { SetProperty(ref _editorial, value); }
        }
    }
}
