using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ArchitecteDemoBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //Atention en Blazor ajouter le Nuget Microsoft.Extensions.Http
            builder.Services.AddHttpClient("api", config =>
            {
                config.BaseAddress = new Uri("https://localhost:7288/api/");
            });

            //FakeCollection
            builder.Services.AddSingleton<IList<Todo>>(sp => new List<Todo>()
            {
                new Todo(1, "Exécuter le déboguage"),
                new Todo(2, "Test Cloture Todo")
            });
            builder.Services.AddScoped<ITodoRepository, FakeTodoService>();


            await builder.Build().RunAsync();
        }
    }
}
