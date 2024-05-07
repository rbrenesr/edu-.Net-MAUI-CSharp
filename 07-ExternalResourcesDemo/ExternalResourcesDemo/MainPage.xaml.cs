using System.Text.Json;

namespace ExternalResourcesDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
            using var reader = new StreamReader(stream);

            var contents = reader.ReadToEnd();

            var people = JsonSerializer.Deserialize<Person>(contents);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            LoadMauiAsset();
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
