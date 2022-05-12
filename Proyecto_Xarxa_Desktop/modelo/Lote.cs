using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    class Lote:ObservableObject
    {
        public Lote(int idLote, ObservableCollection<LibroXarxa> librosLote, Modalidad modalidad, int? niaAlumno)
        {
            IdLote = idLote;
            ModalidadLote = modalidad;
            LibrosLote = librosLote;
            NiaAlumno = niaAlumno;
        }

        public Lote(int idLote, ObservableCollection<LibroXarxa> librosLote, Modalidad modalidad)
        {
            IdLote = idLote;
            ModalidadLote = modalidad;
            LibrosLote = librosLote;
        }

        public Lote()
        {
        }

        private int _idLote;

        [JsonProperty("idLote")]
        public int IdLote
        {
            get => _idLote;
            set { _ = SetProperty(field: ref _idLote, value); }
        }

        private ObservableCollection<LibroXarxa> _librosLote;

        [JsonProperty("librosLote")]
        public ObservableCollection<LibroXarxa> LibrosLote
        {
            get { return _librosLote; }
            set { SetProperty(ref _librosLote, value); }
        }


        private Modalidad _modalidadLote;

        [JsonProperty("modalidadLote")]
        public Modalidad ModalidadLote
        {
            get => _modalidadLote;
            set { _ = SetProperty(field: ref _modalidadLote, value); }
        }

        private int? niaAlumno;

        [JsonProperty("niaAlumno")]
        public int? NiaAlumno
        {
            get { return niaAlumno; }
            set { SetProperty(ref niaAlumno, value); }
        }

    }
}
