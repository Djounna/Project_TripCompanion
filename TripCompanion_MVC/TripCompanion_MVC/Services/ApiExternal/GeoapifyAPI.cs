using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using TripCompanion_MVC.Models.ApiResults;

namespace TripCompanion_MVC.Services.ApiExternal
{
    public class GeoapifyAPI
    {

        private readonly HttpClient _httpClient;

        public GeoapifyAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string[]> Search(string query)
        {
            string testquery = "14, rue francois dufer, namur";

            var values = new Dictionary<string, string>();
            values.Add("text", testquery);
            values.Add("format", "json");
            values.Add("apiKey", "d522ca0618f841a1944c2acfffa2f30c");

            var uri = QueryHelpers.AddQueryString("search", values);

            var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            GeoapifyResult result =  JsonConvert.DeserializeObject<GeoapifyResult>(content);
            string lon, lat;
            lon = result.results[0].lon; 
            lat = result.results[0].lat;

            StringBuilder sb = new();
            sb.Append(lat);
            sb.Append(",");
            sb.Append(lon);

            string[] array = new string[2];
            array[0] = lon;
            array[1] = lat;
            return array;
        }
    }
}