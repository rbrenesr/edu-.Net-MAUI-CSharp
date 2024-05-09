namespace CodeQuotes
{
    public partial class MainPage : ContentPage
    {     
        Random random = new Random();
        List<string> quotes = new List<string>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGenerateQuote_Clicked(object sender, EventArgs e)
        {
            var startColor = System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            var endColor = System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            var gradient = ColorUtility.ColorControls.GetColorGradient(startColor, endColor, 6);

            float stopOffset = .0f;
            var stops  = new GradientStopCollection();
            foreach (var color in gradient)
            {
                stops.Add(new GradientStop(Color.FromArgb(color.Name), stopOffset));
                stopOffset += .2f;
            }

            var gradientBrush = new LinearGradientBrush(stops, new Point(0,0), new Point(1,1));
            GridBackground.Background = gradientBrush;

            var quote = quotes[random.Next(quotes.Count)];
            lblQuote.Text = quote;
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                quotes.Add(reader.ReadLine());
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();
        }

    }

}
