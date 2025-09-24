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

          private HttpClient client;

          public WeatherViewModel()
          {
               client = new HttpClient();
          }

          public ICommand SearchCommand =>
               new Command(async (searchText) =>
               {
                    PlaceName = searchText.ToString();
                    var location =
                         await GetCoordinatesAsync(searchText.ToString());
                    await GetWeather(location);
               });


          private async Task GetWeather(Location location)
          {
               var url =
                    $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";

               IsLoading = true;

               var response =
                 await client.GetAsync(url);

               if (response.IsSuccessStatusCode)
               {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                         var data = await JsonSerializer
                              .DeserializeAsync<WeatherData>(responseStream);
                         WeatherData = data;

                         for(int i = 0; i < WeatherData.daily.time.Length; i++)
                         {
                              var daily2 = new Daily2
                              {
                                   time = WeatherData.daily.time[i],
                                   temperature_2m_max = WeatherData.daily.temperature_2m_max[i],
                                   temperature_2m_min = WeatherData.daily.temperature_2m_min[i],
                                   weathercode = WeatherData.daily.weathercode[i]
                              };
                              WeatherData.daily2.Add(daily2);
                         }
                         IsVisible = true;
                    }
               }
               IsLoading = false;
          }

          private async Task<Location> GetCoordinatesAsync(string address)
          {
               IEnumerable<Location> locations = await Geocoding
                    .Default.GetLocationsAsync(address);

               Location location = locations?.FirstOrDefault();

               if (location != null)
                    Console
                         .WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
               return location;
          }

     }
}
