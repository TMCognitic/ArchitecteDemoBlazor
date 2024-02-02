
using System.Net.Http.Json;
using System.Text.Json;

namespace ArchitecteDemoBlazor.Models.Services
{
    public class TodoService : ITodoRepository
    {
        private readonly HttpClient _client;

        public TodoService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("api");
        }

        public async Task<Todo> AddAsync(string title)
        {
            HttpContent httpContent = JsonContent.Create(new { Title = title });

            using (HttpResponseMessage responseMessage = await _client.PostAsync("todo", httpContent))
            {
                responseMessage.EnsureSuccessStatusCode(); // << si le code n'est pas 2xx EXCEPTION!!!!
                string json = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Todo>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            }
        }

        public async Task<bool> ClotureAsync(int todoId)
        {
            using (HttpResponseMessage responseMessage = await _client.PutAsync($"todo/cloture/{todoId}", null))
            {
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<IEnumerable<Todo>> GetAsync()
        {
            using (HttpResponseMessage responseMessage = await _client.GetAsync("todo"))
            {
                responseMessage.EnsureSuccessStatusCode(); // << si le code n'est pas 2xx EXCEPTION!!!!
                string json = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Todo[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            }
        }
    }
}
