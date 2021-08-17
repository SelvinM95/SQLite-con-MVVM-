using EjercicioVMMV.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioVMMV.ViewModel
{
    public class EmpleadoViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public EmpleadoViewModel() { }

        public EmpleadoViewModel(Empleados empleados)
        {
            Id = empleados.Id;
            nombre = empleados.Nombre;
            apellido= empleados.Apellido;
            edad = empleados.Edad;
            direccion = empleados.Direccion;
            puesto = empleados.Puesto;
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                SetValue(ref nombre, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {
                SetValue(ref apellido, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string edad;
        public string Edad
        {
            get { return edad; }
            set
            {
                SetValue(ref edad, value);
            }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                SetValue(ref direccion, value);
            }
        }


        private string puesto;
        public string Puesto
        {
            get { return puesto; }
            set
            {
                SetValue(ref puesto, value);
            }
        }

        public string FullName
        {
            get { return $"{Nombre} {Apellido}"; }
        }
    }
}
