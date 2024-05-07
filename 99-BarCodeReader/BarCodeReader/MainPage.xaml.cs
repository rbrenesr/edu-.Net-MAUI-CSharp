
using ZXing.Net.Maui;

namespace BarCodeReader
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            barCodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                //Formats = BarcodeFormats.OneDimensional,
                AutoRotate = true,
                Multiple = true,
            };
        }

        private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var firts = e.Results.FirstOrDefault();
            if (firts is null)
            {
                return;
            }
            else
            {
                barCodeReader.IsDetecting = false;



                MainThread.BeginInvokeOnMainThread(() =>
                           {
                               EditorCodBar.Text = firts.Value + "\n" + EditorCodBar.Text;
                               btnScan.Text = "Scan";
                               btnScan.IsEnabled = true;
                           });


            }




            //Device.BeginInvokeOnMainThread(() =>
            //{
            //    EditorCodBar.Text = firts.Value + "\n" + EditorCodBar.Text;
            //});

            //EditorCodBar.Text = EditorCodBar.Text + firts.Value + "\n";

            //Dispatcher.DispatchAsync(async () =>
            //{
            //EditorCodBar.Text = firts.Value + "\n" + EditorCodBar.Text;
            // await DisplayAlert("Barcode", firts.Value, "OK");
            //});
            //    barCodeReader.IsVisible = false;
            //barCodeReader.IsEnabled = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            barCodeReader.IsDetecting = true;
            //((Button)sender).IsEnabled = false;
            btnScan.Text = "Scanning...";
            btnScan.IsEnabled = false;
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            EditorCodBar.Text = "";
            barCodeReader.IsDetecting = true;
        }

        private void btnRepo_Clicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://github.com/rbrenesr/edu-.Net-MAUI-CSharp"));
        }
    }

}
