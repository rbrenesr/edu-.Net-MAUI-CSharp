using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo.Models
{
    public class Persona : INotifyPropertyChanged
    {
        private string nombre;
        private int edad;
        private string direccion;

        //nerera atributos pasra la calse
        public string Nombre
        {
            get => nombre; set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }
        public string Apellido { get; set; }
        public int Edad
        {
            get => edad; set
            {
                edad = value;
                OnPropertyChanged();
            }
        }
        public string Direccion
        {
            get => direccion; set
            {
                direccion = value;
                OnPropertyChanged();
            }
        }
        public string Telefono { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
