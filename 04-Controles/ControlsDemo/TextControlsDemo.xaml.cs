using System.Diagnostics;

namespace ControlsDemo;

public partial class TextControlsDemo : ContentPage
{
	public TextControlsDemo()
	{
		InitializeComponent();
	}

     private void Entry_TextChanged(object sender, TextChangedEventArgs e)
     {
        Debug.WriteLine(txtName.Text);
    }

     private void Entry_Completed(object sender, EventArgs e)
     {
          Debug.WriteLine(txtName.Text);
     }

    private void txtName_TextChanged(object sender, TextChangedEventArgs e)
    {
        Debug.WriteLine(txtName.Text);
    }

    private void txtName_Completed(object sender, EventArgs e)
    {
        Debug.WriteLine(txtName.Text);

    }
}