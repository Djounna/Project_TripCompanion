using Newtonsoft.Json;
using TripCompanion_MVC.Interfaces;

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
        public async Task<T> GetOne<T>(string chemin)  // TODO : A tester
        {
           HttpResponseMessage response =  await _httpClient.GetAsync(chemin);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
           return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<IEnumerable<T>> GetMany<T>(string chemin) // TODO :  A tester
        {
            HttpResponseMessage response = await _httpClient.GetAsync(chemin);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
        }

        public async Task<int> Post<T>(string chemin, T entity)  // EN COURS :  voir pour la valeur de retour, plus voir pour IsSuccessStatusCode faux ?
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(chemin, entity);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot create data");

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task Put<T>(string chemin, T entity)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(chemin, entity);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot udpate data");
        }


        public async Task Delete<T>(string chemin) // EN COURS : voir pour la valeur de retour
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(chemin);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot delete data");

        }


        #endregion

    }
}
