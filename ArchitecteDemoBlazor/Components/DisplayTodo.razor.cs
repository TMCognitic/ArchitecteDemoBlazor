using Microsoft.AspNetCore.Components;

namespace ArchitecteDemoBlazor.Components
{
    public partial class DisplayTodo
    {
        [Parameter]
        public Todo Entity { get; set; } = default!;

        [Parameter]
        public EventCallback<int> TodoClotured { get; set; }

        private void Cloture()
        {
            TodoClotured.InvokeAsync(Entity.Id);
        }
    }
}
