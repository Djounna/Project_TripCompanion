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
    public class GeoapifyAPI
    {
       
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public GeoapifyAPI(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<LocalizationEntity> Search(string query)
        {
            var values = new Dictionary<string, string>();
            values.Add("text", query);
            values.Add("format", "json");
            values.Add("apiKey", _config["Geoapify:ApiKey"]); 

            var uri = QueryHelpers.AddQueryString("search", values);

            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            GeoapifyResult result = JsonConvert.DeserializeObject<GeoapifyResult>(content);

            return new LocalizationEntity
            {
                Longitude = result.results[0].lon,
                Latitude = result.results[0].lat
            };
        }
    }
}
