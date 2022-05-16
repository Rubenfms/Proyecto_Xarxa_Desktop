using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    class LoteInformeEtiquetas : ObservableObject
    {

        public LoteInformeEtiquetas(int idLote, string curso)
        {
            IdLote = idLote;
            Curso = curso;
        }

        public LoteInformeEtiquetas(int idLote, string curso, string nombreAlumno)
        {
            IdLote = idLote;
            Curso = curso;
            NombreAlumno = nombreAlumno;
        }

        public LoteInformeEtiquetas() { }

        private string _nombreAlumno;
        public string NombreAlumno
        {
            get => _nombreAlumno;
            set { SetProperty(ref _nombreAlumno, value); }
        }

        private int _idLote;
        public int IdLote
        {
            get => _idLote;
            set { SetProperty(ref _idLote, value); }
        }

        private string _curso;
        public string Curso
        {
            get => _curso;
            set { SetProperty(ref _curso, value); }
        }

    }
}
