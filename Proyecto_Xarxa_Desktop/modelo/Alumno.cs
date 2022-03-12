﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Proyecto_Xarxa_Desktop.enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Xarxa_Desktop.modelo
{
    class Alumno:ObservableObject
    {
        private int nia;

        private Lote _lote;

        public Lote Lote
        {
            get { return _lote; }
            set { SetProperty(ref _lote, value); }
        }

        private int _nia;

        public int Nia
        {
            get { return _nia; }
            set { SetProperty(ref _nia, value); }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _apellido1;

        public string Apellido1
        {
            get { return _apellido1; }
            set { SetProperty(ref _apellido1, value); }
        }

        private string _apellido2;

        public string Apellido2
        {
            get { return _apellido2; }
            set { SetProperty(ref _apellido2, value); }
        }

        private DateTime _fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { SetProperty(ref _fechaNacimiento, value); }
        }

        private EstadoMatricula _matricula;

        public EstadoMatricula Matricula
        {
            get { return _matricula; }
            set { SetProperty(ref _matricula, value); }
        }

        private string _curso;

        public string Curso
        {
            get { return _curso; }
            set { SetProperty(ref _curso, value); }
        }

        private string _grupo;

        public string Grupo
        {
            get { return _grupo; }
            set { SetProperty(ref _grupo, value); }
        }

        private string _incidencias;

        public string Incidencias
        {
            get { return _incidencias; }
            set { SetProperty(ref _incidencias, value); }
        }

        private bool _perteneceXarxa;

        public bool PerteneceXarxa
        {
            get { return _perteneceXarxa; }
            set { SetProperty(ref _perteneceXarxa, value); }
        }

        // Constructor sin lote
        public Alumno(int nia, string nombre, string apellido1, string apellido2, DateTime fechaNacimiento, EstadoMatricula matricula, string curso, string grupo, string incidencias, bool perteneceXarxa)
        {
            Nia = nia;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            FechaNacimiento = fechaNacimiento;
            Matricula = matricula;
            Curso = curso;
            Grupo = grupo;
            Incidencias = incidencias;
            PerteneceXarxa = perteneceXarxa;
        }

        // Constructor sin lote y sin PerteneceXarxa
        public Alumno(int nia, string nombre, string apellido1, string apellido2, DateTime fechaNacimiento, EstadoMatricula matricula, string curso, string grupo, string incidencias)
        {
            Nia = nia;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            FechaNacimiento = fechaNacimiento;
            Matricula = matricula;
            Curso = curso;
            Grupo = grupo;
            Incidencias = incidencias;
        }
        public Alumno()
        {
        }
    }
}
