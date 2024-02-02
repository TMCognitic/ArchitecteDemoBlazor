using ArchitecteDemoBlazor.Models.Entities;

namespace ArchitecteDemoBlazor.Models.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAsync();
        Task<Todo> AddAsync(string title); //<-- Si CQS recoit une commande
        Task<bool> ClotureAsync(int todoId);
    }
}
