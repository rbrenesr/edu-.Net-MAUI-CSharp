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
    public class WeatherViewModel
    {
        public WeatherData WeatherData { get; set; }
        private HttpClient _client;

        public WeatherViewModel()
        {            
            _client = new HttpClient();
        }

        public ICommand SearchCommand =>
            new Command(async (searchText) =>
                { 
                    var location = 
                    await GetCoordinatesAsync(searchText.ToString());
                    await GetWeatherDataAsync(location);
                });

        private async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            if (location != null) {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
            }

            return location;
        }

       private async Task GetWeatherDataAsync(Location location)
        {
            var url 
                = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,weather_code&daily=weather_code,temperature_2m_max,temperature_2m_min";
                  //$"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";

            var response = 
                await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                { 
                    var data = 
                        await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
                    WeatherData = data;
                }
            }
        }
    }
}
