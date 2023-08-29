using System.Data;

namespace BestbitePizza.DataServices
{
    public interface IDataContext
    {
        IDbConnection CreateConnection();
        Task<List<T>> GetAll<T>(string query);
    }
}
