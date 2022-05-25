using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Proyecto_Xarxa_Desktop.mensajeria;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    /// <summary>
    /// VM de CrearModalidadDialog
    /// </summary>
    /// <seealso cref="Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject" />
    class CrearModalidadVM : ObservableObject
    {
        /// <summary>
        /// La lista cursos registrados en la BD
        /// </summary>
        private ObservableCollection<string> listaCursos;

        /// <summary>
        /// Gets or sets the lista cursos.
        /// </summary>
        /// <value>
        /// La lista cursos registrados en la BD
        /// </value>
        public ObservableCollection<string> ListaCursos
        {
            get { return listaCursos; }
            set { SetProperty(ref listaCursos, value); }
        }

        /// <summary>
        /// El libro seleccionado.
        /// </summary>
        private Libro libroSeleccionado;

        /// <summary>
        /// Gets or sets the libro seleccionado.
        /// </summary>
        /// <value>
        /// El libro seleccionado.
        /// </value>
        public Libro LibroSeleccionado
        {
            get { return libroSeleccionado; }
            set { SetProperty(ref libroSeleccionado, value); }
        }

        /// <summary>
        /// La nueva modalidad que vamos a crear.
        /// </summary>
        private Modalidad nuevaModalidad;

        /// <summary>
        /// Gets or sets the nueva modalidad.
        /// </summary>
        /// <value>
        /// La nueva modalidad que vamos a crear
        /// </value>
        public Modalidad NuevaModalidad
        {
            get { return nuevaModalidad; }
            set { SetProperty(ref nuevaModalidad, value); }
        }

        /// <summary>
        /// The servicio API
        /// </summary>
        private readonly ServicioAPI servicioAPI = new ServicioAPI(Properties.Settings.Default.CadenaConexionLocalhost);

        /// <summary>
        /// Initializes a new instance of the <see cref="CrearModalidadVM"/> class.
        /// </summary>
        public CrearModalidadVM()
        {
            NuevaModalidad = new Modalidad();

            if (NuevaModalidad.LibrosModalidad == null) NuevaModalidad.LibrosModalidad = new ObservableCollection<Libro>();
            ListaCursos = ServicioSQL.GetCursos();

            // Mensajería de añadir libro
            WeakReferenceMessenger.Default.Register<AnyadirLibroAModalidadMessage>(this, (r, m) =>
            {
                NuevaModalidad.LibrosModalidad.Add(m.Value);
            });

        }


        /// <summary>
        /// Abrre la vista anyadir libro.
        /// </summary>
        public void AbrirVistaAnyadirLibro()
        {
            ServicioNavegacion.AbrirVistaAnyadirLibroModalidad();
        }

        /// <summary>
        /// Elimina un libro de la modalidad.
        /// </summary>
        public void EliminarLibro()
        {
            if (LibroSeleccionado != null)
            {
                NuevaModalidad.LibrosModalidad.Remove(LibroSeleccionado);
            }
            else ServicioDialogos.ServicioMessageBox("Selecciona un libro para eliminarlo.", "Selecciona un libro primero", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        /// <summary>
        /// Guarda la modalidad.
        /// </summary>
        /// <returns>Devuelve true si todo ha ido bien</returns>
        public bool GuardarModalidad()
        {
            if(ComprobarDatosIntroducidos())
            {
                // TODO: Controlar tema id modalidad
                HttpStatusCode? statusCode = servicioAPI.PostModalidad(NuevaModalidad);
                ServicioDialogos.ServicioMessageBox($"Resultado de la creación de la modalidad: {statusCode}", statusCode.ToString(), System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.None);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Comprueba los datos introducidos en el formulario.
        /// </summary>
        /// <returns></returns>
        public bool ComprobarDatosIntroducidos()
        {
            if (NuevaModalidad.Curso == null)
            {
                ServicioDialogos.ServicioMessageBox("Selecciona un curso.", "Selecciona un curso", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return false;
            }
            else if (NuevaModalidad.Nombre == null || NuevaModalidad.Nombre.Length <= 0)
            {
                ServicioDialogos.ServicioMessageBox("Escribe un nombre para la modalidad.", "Escribe un nombre", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return false;
            }
            else if(NuevaModalidad.LibrosModalidad.Count <= 0)
            {
                ServicioDialogos.ServicioMessageBox("Introduce al menos un libro.", "Introduce libros", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
