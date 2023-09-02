using BestbitePizza.Models;

namespace BestbitePizza.Services
{
    public interface IMenuServiceAggregated
    {
        Task<IEnumerable<CategorizedMenu>> GetCategorizedMenuItems();
    }
}
