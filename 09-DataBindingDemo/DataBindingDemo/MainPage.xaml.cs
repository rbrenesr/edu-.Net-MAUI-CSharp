using DataBindingDemo.Models;

namespace DataBindingDemo
{
    public partial class MainPage : ContentPage
    {
        Persona persona = new Persona();

        public MainPage()
        {
            InitializeComponent();

            persona = new Persona();
            persona.Nombre = "Juan";
            persona.Apellido = "Perez";
            persona.Edad = 25;
            persona.Direccion = "Calle 123";
            persona.Telefono = "1234567890";

            //Binding persopnaBinding = new Binding();
            //persopnaBinding.Source = persona;
            //persopnaBinding.Path = "Nombre";
            //lblNombre.SetBinding(Label.TextProperty, persopnaBinding);

            //lblApellido.BindingContext = persona;
            //lblApellido.SetBinding(Label.TextProperty, "Apellido");

            BindingContext = persona;

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
          
            persona.Nombre = "Pedro";
            persona.Apellido = "Gomez";
            persona.Edad = 30;
        }
    }

}
