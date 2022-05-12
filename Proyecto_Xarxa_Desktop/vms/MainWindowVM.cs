using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.modelo;
using Proyecto_Xarxa_Desktop.servicios;
using Proyecto_Xarxa_Desktop.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proyecto_Xarxa_Desktop.vms
{
    class MainWindowVM : ObservableObject
    {
        private Usuario usuarioLogeado;

        public Usuario UsuarioLogeado
        {
            get { return usuarioLogeado; }
            set { SetProperty(ref usuarioLogeado, value); }
        }

        private UserControl pestanyaActual;

        public UserControl PestanyaActual
        {
            get { return pestanyaActual; }
            set { SetProperty(ref pestanyaActual, value); }
        }

        public RelayCommand GenerarLoteCommand { get; }
        public RelayCommand AbrirVistaLotesCommand { get; }
        public RelayCommand AbrirVistaAlumnosCommand { get; }
        public RelayCommand AbrirVistaLibrosCommand { get; }
        public RelayCommand AbrirVistaInformesCommand { get; }

        public MainWindowVM()
        {
            // Instancia vacía para que al iniciar el programa no aparezca ningún UserControl seleccionado
            PestanyaActual = new VistaInicialContentControl();
            UsuarioLogeado = ServicioValidarUsuario.UsuarioActual;

            // Comandos
            AbrirVistaLotesCommand = new RelayCommand(AbrirVistaLotes);
            AbrirVistaAlumnosCommand = new RelayCommand(AbrirVistaAlumnos);
            AbrirVistaLibrosCommand = new RelayCommand(AbrirVistaLibros);
            GenerarLoteCommand = new RelayCommand(AbrirVistaGenerarLote);
            AbrirVistaInformesCommand = new RelayCommand(AbrirVistaInformes);
        }

        public void AbrirVistaLotes() => PestanyaActual = ServicioNavegacion.AbrirVistaLotes();

        public void AbrirVistaAlumnos() => PestanyaActual = ServicioNavegacion.AbrirVistaAlumnos();
        public void AbrirVistaLibros() => PestanyaActual = ServicioNavegacion.AbrirVistaLibros();

        public void AbrirOpcionesSU() => ServicioNavegacion.AbrirVistaOpcionesSU();

        public void CerrarSesion()
        {
            ServicioNavegacion.AbrirVistaLogIn();
            UsuarioLogeado = new Usuario();
        }

        public void AbrirVistaGenerarLote() => ServicioNavegacion.AbrirVistaGenerarLote();
        public void AbrirVistaDarDeAltaAlumno() => ServicioNavegacion.AbrirVistaDarDeAlta();
        public void AbrirVistaInformes() => PestanyaActual = ServicioNavegacion.AbrirVistaInformes();

    }
}
