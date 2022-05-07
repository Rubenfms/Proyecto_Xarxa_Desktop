using Microsoft.Toolkit.Mvvm.ComponentModel;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class LibrosVM : ObservableObject
    {
        private Libro libroSeleccionado;

        public Libro LibroSeleccionado
        {
            get { return libroSeleccionado; }
            set { SetProperty(ref libroSeleccionado, value); }
        }

        private ObservableCollection<Libro> listaLibros;

        public ObservableCollection<Libro> ListaLibros
        {
            get { return listaLibros; }
            set { SetProperty(ref listaLibros, value); }
        }

        private ServicioAPI servicioAPI;
        public LibrosVM()
        {
            // Api
            servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

            // Carga libros
            ListaLibros = servicioAPI.GetLibros();
        }
    }
}
