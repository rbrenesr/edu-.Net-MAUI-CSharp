using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Weather.MVVM.Models;

namespace Weather.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {
        public WeatherData WeatherData { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; } =
            DateTime.Now;

        public bool IsVisible { get; set; }
        public bool IsLoading { get; set; }

        private HttpClient _client;



        public WeatherViewModel()
        {
            _client = new HttpClient();
        }

        public ICommand SearchCommand =>
            new Command(async (searchText) =>
                {

                    PlaceName = searchText.ToString();
                    var location =
                    await GetCoordinatesAsync(searchText.ToString());
                    await GetWeatherDataAsync(location);
                });

        private async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            if (location != null)
            {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
            }

            return location;
        }

        private async Task GetWeatherDataAsync(Location location)
        {
            var url
                = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,apparent_temperature,weather_code,wind_speed_10m&hourly=temperature_2m&daily=weather_code,apparent_temperature_max,apparent_temperature_min&timezone=America%2FNew_York";

            IsLoading = true;

            var response =
                await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data =
                        await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
                    WeatherData = data;

                    for (int i = 0; i < WeatherData.daily.time.Length; i++)
                    {
                        var daily2 = new Daily2
                        {
                            time = WeatherData.daily.time[i],
                            apparent_temperature_max = WeatherData.daily.apparent_temperature_max[i],
                            apparent_temperature_min = WeatherData.daily.apparent_temperature_min[i],
                            weather_code = WeatherData.daily.weather_code[i]
                        };

                        WeatherData.daily2.Add(daily2);
                    }

                    IsVisible = true;
                }
            }
            IsLoading = false;
        }
    }
}
