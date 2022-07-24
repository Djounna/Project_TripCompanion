using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models.ApiResults;

namespace TripCompanion_MVC.Services.ApiExternal
{
    public class NominatimAPI
    {
        
        private readonly HttpClient _httpClient;

        public NominatimAPI( HttpClient httpClient)
        {          
            _httpClient = httpClient;
        }

        public async Task Search(string query)
        {
            string testquery = "namur";
            //string phrase = "Rue François Dufer, Namur";
            //string[] words = phrase.Split(' ');

            //StringBuilder sb1 = new();
            //foreach (var word in words)
            //{
            //    sb1.Append(word);
            //    sb1.Append("+");
            //}
            //testquery = sb1.ToString();

            var values = new Dictionary<string, string>();
            values.Add("q", testquery);
            values.Add("format", "jsonv2");
                        
            var uri = QueryHelpers.AddQueryString("search", values);


            var response =  await _httpClient.GetStringAsync(uri);

            //if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            //var content = await response.Content.ReadAsStringAsync();
            //NominatimResult nom =  JsonConvert.DeserializeObject<NominatimResult>(content);
            string lon, lat;
            //lon = nom.lon; lat = nom.lat;

            //StringBuilder sb2 = new();
            //sb2.Append(lon);
            //sb2.Append(",");
            //sb2.Append(lat);




        }

    }
}
