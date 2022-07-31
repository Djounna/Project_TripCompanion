using DAL.Entities.APIEntity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ApiRepos
{
    public class OpenWeatherMapAPI
    {       
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public OpenWeatherMapAPI(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<WeatherEntity> Search(string lat, string lon)
        {
            string latb = lat.Substring(0, 5);
            string lonb = lon.Substring(0, 5);

            var values = new Dictionary<string, string>();
            values.Add("lat", latb);
            values.Add("lon", lonb);
            values.Add("units", "metric");
            values.Add("APPID", _config["OpenWeatherMap:ApiKey"]);

            var uri = QueryHelpers.AddQueryString("weather", values);

            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            OpenWeatherMapResult result = JsonConvert.DeserializeObject<OpenWeatherMapResult>(content);

            return new WeatherEntity
            {
                temperature = result.main.Temp,
                humidity = result.main.Humidity
            };
        }

    }
}
