namespace ControlsDemo;

public partial class InputControlsDemo : ContentPage
{
	public InputControlsDemo()
	{
		InitializeComponent();
	}

     private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
     {
		  lblSlider.Text = slider.Value.ToString("N2");
	 }

     private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
     {
		  if (stepper != null)
		  {
			   lblSlider.Text = stepper.Value.ToString("N2");
		  }
	 }
}