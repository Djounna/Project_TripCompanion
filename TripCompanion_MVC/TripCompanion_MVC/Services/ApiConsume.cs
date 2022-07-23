using Newtonsoft.Json;
using System.Net.Http.Headers;
using TripCompanion_MVC.Interfaces;
using TripCompanion_MVC.Models;

namespace TripCompanion_MVC.Services
{
    public class ApiConsume : IApiConsume // TODO : ne pas oublier de mettre les signatures des méthodes dans l'interface.
    {
        #region Ctor

        private readonly HttpClient _httpClient;

        public ApiConsume(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        #endregion

        #region Generics
        public async Task<T> GetOne<T>(string chemin, string? bearerToken = null)  // TODO : A tester
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            HttpResponseMessage response =  await _httpClient.GetAsync(chemin);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
           return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<IEnumerable<T>> GetMany<T>(string chemin, string? bearerToken = null) // TODO :  A tester
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            HttpResponseMessage response = await _httpClient.GetAsync(chemin);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
        }

        public async Task<T> Post<T>(string chemin, T entity, string? bearerToken=null)  // EN COURS :  voir pour la valeur de retour, plus voir pour IsSuccessStatusCode faux ?
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(chemin, entity);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot create data");

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task Put<T>(string chemin, T entity, string? bearerToken=null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(chemin, entity);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot udpate data");
        }


        public async Task Delete<T>(string chemin, string? bearerToken=null) // EN COURS : voir pour la valeur de retour
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            HttpResponseMessage response = await _httpClient.DeleteAsync(chemin);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot delete data");

        }


        #endregion

    }
}
