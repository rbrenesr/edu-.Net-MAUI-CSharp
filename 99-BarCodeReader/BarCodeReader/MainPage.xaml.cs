namespace BarCodeReader
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            barCodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                AutoRotate = true,
                Multiple = true,
            };
        }

        private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var firts = e.Results.FirstOrDefault();
            if (firts is null)
                return;


            Device.BeginInvokeOnMainThread(() =>
            {
                EditorCodBar.Text += firts.Value + "\n";
            });

            //EditorCodBar.Text = EditorCodBar.Text+ firts.Value + "\n";
            //
            //Dispatcher.DispatchAsync(async () =>
            //{
            //    await DisplayAlert("Barcode", firts.Value, "OK");
            //});
        }
    }

}
