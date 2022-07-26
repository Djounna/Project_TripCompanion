using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using TripCompanion_MVC.Models.ApiResults;

namespace TripCompanion_MVC.Services.ApiExternal
{
    public class OpenWeatherMapAPI
    {
        public class WeatherResult
        {
            public double temp { get; set; } // Temperature
            public double hum { get; set; } // Humidity
        }

        private readonly HttpClient _httpClient;

        public OpenWeatherMapAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResult> Search(string lat, string lon)
        {
            string latb = lat.Substring(0, 5);
            string lonb = lon.Substring(0, 5);

            var values = new Dictionary<string, string>();
            values.Add("lat",latb);
            values.Add("lon", lonb);
            values.Add("units", "metric");
            values.Add("APPID", "605a7f4a36bb08a5d53facb9c7b33e16");

            var uri = QueryHelpers.AddQueryString("weather", values);

            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            OpenWeatherMapResult result = JsonConvert.DeserializeObject<OpenWeatherMapResult>(content);

            return new WeatherResult
            {
                temp = result.main.Temp,
                hum = result.main.Humidity
            };
        }

    }
}
