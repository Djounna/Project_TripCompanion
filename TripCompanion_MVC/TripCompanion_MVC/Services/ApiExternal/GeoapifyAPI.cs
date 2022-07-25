using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using TripCompanion_MVC.Models.ApiResults;

namespace TripCompanion_MVC.Services.ApiExternal
{
    public class GeoapifyAPI
    {
        public class CoordonateResult
        {
            public double Long { get; set; }
            public double Lat { get; set; }
        }

        private readonly HttpClient _httpClient;

        public GeoapifyAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CoordonateResult> Search(string query)
        {
            var values = new Dictionary<string, string>();
            values.Add("text", query);
            values.Add("format", "json");
            values.Add("apiKey", "d522ca0618f841a1944c2acfffa2f30c");

            var uri = QueryHelpers.AddQueryString("search", values);

            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            GeoapifyResult result =  JsonConvert.DeserializeObject<GeoapifyResult>(content);

            return new CoordonateResult
            {
                Long = result.results[0].lon,
                Lat = result.results[0].lat
            };
        }
    }
}