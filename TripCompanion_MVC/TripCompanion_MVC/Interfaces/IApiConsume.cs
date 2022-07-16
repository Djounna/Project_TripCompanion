namespace TripCompanion_MVC.Interfaces
{
    public interface IApiConsume
    {
        Task<T> GetOne<T>(string chemin, string? bearerToken = null);
        Task<IEnumerable<T>> GetMany<T>(string chemin, string? bearerToken = null);
        Task<T> Post<T>(string chemin, T entity);
        Task Put<T>(string chemin, T entity);
        Task Delete<T>(string chemin);
    }
}
