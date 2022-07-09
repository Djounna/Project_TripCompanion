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
           var result = await response.Content.ReadAsStringAsync();
           return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<IEnumerable<T>> GetMany<T>(string chemin) // TODO :  A tester
        {
            HttpResponseMessage response = await _httpClient.GetAsync(chemin);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
        }

        public async Task<int> Post<T>(string chemin, T body)  // EN COURS :  voir pour la valeur de retour, plus voir pour IsSuccessStatusCode faux ?
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(chemin, body);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(result);
        }

        public async Task Delete<T>(string chemin) // EN COURS : voir pour la valeur de retour
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(chemin);

        }


        #endregion

    }
}
