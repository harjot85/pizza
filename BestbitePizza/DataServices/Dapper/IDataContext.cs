namespace BestbitePizza.DataServices.Dapper
{
    public interface IDataContext
    {
        Task<T> Get<T>(string query);
        Task<List<T>> GetAll<T>(string query);
    }
}
