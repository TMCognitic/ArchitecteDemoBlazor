using Microsoft.AspNetCore.Components;

namespace ArchitecteDemoBlazor.Pages
{
    public partial class CreateTodo
    {
        [Inject]
        private ITodoRepository Repository { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        private CreateTodoForm Form { get; set; } = default!;

        protected override void OnInitialized()
        {
            Form = new CreateTodoForm();
        }

        private async void Save()
        {
            await Repository.AddAsync(Form.Title);
            NavigationManager.NavigateTo("/");
        }
    }
}
