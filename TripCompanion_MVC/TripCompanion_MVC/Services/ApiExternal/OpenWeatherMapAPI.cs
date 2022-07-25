using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace TripCompanion_MVC.Services.ApiExternal
{
    public class OpenWeatherMapAPI
    {
        public class WeatherResult
        {
            public double Long { get; set; }
            public double Lat { get; set; }
        }

        private readonly HttpClient _httpClient;

        public OpenWeatherMapAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResult> Search(string lat, string lon)
        {
            var values = new Dictionary<string, string>();
            values.Add("lat",lat);
            values.Add("lon", lon);
            values.Add("apiKey", "");

            var uri = QueryHelpers.AddQueryString("search", values);

            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            //OpenWeatherMapResult result = JsonConvert.DeserializeObject<OpenWeatherMapResult>(content);

            return new WeatherResult
            {
                
            };
        }

    }
}
