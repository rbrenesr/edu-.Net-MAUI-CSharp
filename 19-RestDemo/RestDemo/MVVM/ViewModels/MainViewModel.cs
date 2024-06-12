using RestDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestDemo.MVVM.ViewModels
{
    public class MainViewModel
    {
        HttpClient client;
        JsonSerializerOptions serializarOptions;
        private string baseUri = "https://6669e7392e964a6dfed710c3.mockapi.io";
        private List<User> Users;

        public MainViewModel()
        {
            client = new HttpClient();
            serializarOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

        }

        public ICommand GetAllUsersCommand => new Command(async () =>
        {
            var url = $"{baseUri}/users";

            //var response = await client.GetStringAsync(url);
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();// respuestas muy grandes puede tener problemas de rendimiento.

                using (var responseString =
                await response.Content.ReadAsStreamAsync())
                {
                    var users = await JsonSerializer.DeserializeAsync<List<User>>(responseString, serializarOptions);

                    Users = users;

                    foreach (var user in users)
                    {
                        Console.WriteLine(user.name);
                    }
                }
            }
            else
            {
                // Leer el contenido de la respuesta de error
                var errorContent = await response.Content.ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("Error", $"Error al obtener los usuarios: {response.StatusCode}", "Ok");
            }


        });

        public ICommand GetSingleUserCommand => new Command(async () =>
        {
            var url = $"{baseUri}/users/19";

            //var response = await client.GetStringAsync(url);
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();// respuestas muy grandes puede tener problemas de rendimiento.

                using (var responseString =
                await response.Content.ReadAsStreamAsync())
                {
                    var user = await JsonSerializer.DeserializeAsync<User>(responseString, serializarOptions);
                    await App.Current.MainPage.DisplayAlert("Info", user + "", "Ok");

                }

            }
            else
            {
                // Leer el contenido de la respuesta de error
                var errorContent = await response.Content.ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("Error", $"Error al obtener los usuarios: {response.StatusCode}", "Ok");
            }


        });

        public ICommand AddUserCommand => new Command(async () =>
        {
            var url = $"{baseUri}/users";

            var user = new User
            {
                createdAt = DateTime.Now,
                name = "Juan",
                alias = "Juanito",
                avatar = "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png"
            };


            var userJson = JsonSerializer.Serialize<User>(user, serializarOptions);
            StringContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);


            if (response.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Info", user + "", "Ok");
            }
            else
            {
                // Leer el contenido de la respuesta de error
                var errorContent = await response.Content.ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("Error", $"Error al insertar el usuario: {response.StatusCode}", "Ok");
            }


        });

        public ICommand UpdateUserCommand => new Command(async () =>
        {
            var user = Users.FirstOrDefault(x => x.id == "3");
            user.name = "Pedro Pedro Pedro Pedro pe";
            var url = $"{baseUri}/users/{user.id}";

            var userJson = JsonSerializer.Serialize<User>(user, serializarOptions);
            StringContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);


            if (response.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Info actualizado", user + "", "Ok");
            }
            else
            {
                // Leer el contenido de la respuesta de error
                var errorContent = await response.Content.ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("Error", $"Error al insertar el usuario: {response.StatusCode}", "Ok");
            }


        });

        public ICommand DeleteUserCommand => new Command(async () =>
        {
            var user = Users.FirstOrDefault(x => x.id == "51");            
            var url = $"{baseUri}/users/{user.id}";

            var userJson = JsonSerializer.Serialize<User>(user, serializarOptions);
            StringContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await client.DeleteAsync(url);


            if (response.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Info eliminado", user + "", "Ok");
            }
            else
            {
                // Leer el contenido de la respuesta de error
                var errorContent = await response.Content.ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("Error", $"Error al insertar el usuario: {response.StatusCode}", "Ok");
            }


        });
    }
}
