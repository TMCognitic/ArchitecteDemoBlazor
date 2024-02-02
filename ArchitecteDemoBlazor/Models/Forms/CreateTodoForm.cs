using System.ComponentModel.DataAnnotations;

namespace ArchitecteDemoBlazor.Models.Forms
{
    public class CreateTodoForm
    {
        [Required]
        public string Title { get; set; } = default!;
    }
}
