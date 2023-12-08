using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    internal class Program
    {
        static async Task Main()
        {
            await GetWeather("https://goweather.herokuapp.com/weather/istanbul", "Istanbul");
            await GetWeather("https://goweather.herokuapp.com/weather/izmir", "Izmir");
            await GetWeather("https://goweather.herokuapp.com/weather/ankara", "Ankara");
        }

        static async Task GetWeather(string apiUrl, string cityName)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);

                    Console.WriteLine("============================================");
                    Console.WriteLine($"Weather Information - {cityName}");
                    Console.WriteLine("============================================");
                    Console.WriteLine($"City: {weatherData.City}");
                    Console.WriteLine($"Temperature: {weatherData.Temperature}");
                    Console.WriteLine($"Current Status: {weatherData.Description}");
                    Console.WriteLine("============================================");

                    Console.WriteLine("Weather Forecast For Next Three Days:");
                    foreach (var weather in weatherData.Forecast)
                    {
                        Console.WriteLine("============================================");
                        Console.WriteLine($"Date: {weather.Day}");
                        Console.WriteLine($"Minimum Temperature: {weather.TemperatureMin}");
                        Console.WriteLine($"Maximum Temperature: {weather.TemperatureMax}");
                        Console.WriteLine($"Current Status: {weather.Description}");
                        Console.WriteLine();
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error Occured: {e.Message}");
                }
            }
        }
    }
}