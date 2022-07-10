namespace TripCompanion_MVC.Interfaces
{
    public interface IApiConsume
    {
        Task<T> GetOne<T>(string chemin);
        Task<IEnumerable<T>> GetMany<T>(string chemin);
        Task<int> Post<T>(string chemin, T entity);
        Task Put<T>(string chemin, T entity);
        Task Delete<T>(string chemin);
    }
}
