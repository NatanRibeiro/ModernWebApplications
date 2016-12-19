namespace ModernWebStore.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int Id { get; set;}
        public string Title { get; set; }

        public UpdateCategoryCommand(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
