using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Proyecto_Xarxa_Desktop.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.vms
{
    class CargarCSVDialogVM : ObservableObject
    {
        /// <summary>
        /// La ruta  del primer CSV que contedrá la lista general de los alumnos
        /// </summary>
        private string rutaPrimerCSV;

        /// <summary>
        /// Gets or sets la ruta del primer CSV.
        /// </summary>
        /// <value>
        /// La ruta  del primer CSV que contedrá la lista general de los alumnos
        /// </value>
        public string RutaPrimerCSV
        {
            get { return rutaPrimerCSV; }
            set { SetProperty(ref rutaPrimerCSV, value); }
        }

        /// <summary>
        /// La ruta del segundo CSV que aplicará los grupos de primero (A, B, C, D, etc)
        /// </summary>
        private string rutaSegundoCSV;

        /// <summary>
        /// Gets or sets la ruta del segundo CSV.
        /// </summary>
        /// <value>
        /// La ruta del segundo CSV que aplicará los grupos de primero (A, B, C, D, etc)
        /// </value>
        public string RutaSegundoCSV
        {
            get { return rutaSegundoCSV; }
            set { SetProperty(ref rutaSegundoCSV, value); }
        }

        /// <summary>
        /// La ruta del tercer CSV que contiene los alumnos de la Xarxa
        /// </summary>
        private string rutaTercerCSV;

        /// <summary>
        /// Gets or sets la ruta del tercer CSV.
        /// </summary>
        /// <value>
        /// La ruta del tercer CSV que contiene los alumnos de la Xarxa
        /// </value>
        public string RutaTercerCSV
        {
            get { return rutaTercerCSV; }
            set { SetProperty(ref rutaTercerCSV, value); }
        }

        /// <summary>
        /// Booleano bindeado al checkbox. Si está a true se borrarán todos los alumnos que no pertenezcan a la Xarxa.
        /// </summary>
        private bool borrarAlumnosNoXarxa;

        /// <summary>
        /// Gets or sets a value indicating whether [borrar alumnos no xarxa].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [borrar alumnos no xarxa]; otherwise, <c>false</c>.
        /// </value>
        public bool BorrarAlumnosNoXarxa
        {
            get { return borrarAlumnosNoXarxa; }
            set { borrarAlumnosNoXarxa = value; }
        }


        /// <summary>
        /// Gets the examinar primer CSV command.
        /// </summary>
        /// <value>
        /// The examinar primer CSV command.
        /// </value>
        public RelayCommand ExaminarPrimerCSVCommand { get; }

        /// <summary>
        /// Gets the examinar segundo CSV command.
        /// </summary>
        /// <value>
        /// The examinar segundo CSV command.
        /// </value>
        public RelayCommand ExaminarSegundoCSVCommand { get; }

        /// <summary>
        /// Gets the examinar tercer CSV command.
        /// </summary>
        /// <value>
        /// The examinar tercer CSV command.
        /// </value>
        public RelayCommand ExaminarTercerCSVCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CargarCSVDialogVM"/> class.
        /// </summary>
        public CargarCSVDialogVM()
        {
            BorrarAlumnosNoXarxa = false;
            ExaminarPrimerCSVCommand = new RelayCommand(ExaminarPrimerCSV);
            ExaminarSegundoCSVCommand = new RelayCommand(ExaminarSegundoCSV);
            ExaminarTercerCSVCommand = new RelayCommand(ExaminarTercerCSV);
        }

        public void ExaminarPrimerCSV()
        {
            RutaPrimerCSV = ServicioDialogos.OpenFileDialogService();
        }

        public void ExaminarSegundoCSV()
        {
            RutaSegundoCSV = ServicioDialogos.OpenFileDialogService();
        }

        public void ExaminarTercerCSV()
        {
            RutaTercerCSV = ServicioDialogos.OpenFileDialogService();
        }

        public void HacerCarga()
        {
            ServicioCsv.RealizarCargaCSV(RutaPrimerCSV, RutaSegundoCSV, RutaTercerCSV, BorrarAlumnosNoXarxa);
        }
    }
}
