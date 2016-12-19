namespace ModernWebStore.Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public string Title { get; set; }

        public CreateCategoryCommand(string title)
        {
            this.Title = title;
        }
    }
}
