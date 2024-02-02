using Microsoft.AspNetCore.Components;

namespace ArchitecteDemoBlazor.Pages
{
    public partial class Home
    {
        private string? ErrorMessage { get; set; }
        private IList<Todo>? Items { get; set; }

        [Inject]
        private ITodoRepository Repository { get; set; } = default!;

        private bool CanRender { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Items = new List<Todo>(await Repository.GetAsync());                           
            }
            catch (HttpRequestException ex) when(ex.Message == "TypeError: Failed to fetch")
            {
                ErrorMessage = "L'api semble indisponible, veuillez réessayer plus tard";
            }
            catch (Exception)
            {
                ErrorMessage = "Une erreur est survenue, veuillez réessayer plus tard"; ;
            }
            CanRender = true;
        }

        protected override bool ShouldRender()
        {
            return CanRender;
        }

        private async Task ClotureToDo(int todoId)
        {
            if(await Repository.ClotureAsync(todoId)) 
            {
                Todo todo = Items!.Single(td => td.Id == todoId);
                todo.Done = true;
            }
        }
    }
}
