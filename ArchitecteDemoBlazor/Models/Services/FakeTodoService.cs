using ArchitecteDemoBlazor.Models.Entities;
using ArchitecteDemoBlazor.Models.Repositories;

namespace ArchitecteDemoBlazor.Models.Services
{
    public class FakeTodoService : ITodoRepository
    {
        private readonly IList<Todo> _items;

        public FakeTodoService(IList<Todo> items)
        {
            _items = items;
        }

        public async Task<Todo> AddAsync(string title)
        {
            return await Task.Run(() =>
            {
                int id = (_items.Count == 0) ? 1 : _items.Max(td => td.Id) + 1;
                Todo newTodo = new Todo(id, title);

                _items.Add(newTodo);
                return newTodo;
            });
        }

        public async Task<IEnumerable<Todo>> GetAsync()
        {
            return await Task.Run(() =>
            {
                return _items;
            });
        }

        public async Task<bool> ClotureAsync(int todoId)
        {
            return await Task.Run(() =>
            {
                Todo? todo = _items.SingleOrDefault(td => td.Id == todoId);

                if (todo is null)
                    return false;

                todo.Done = true;

                return true;
            });
        }
    }
}
