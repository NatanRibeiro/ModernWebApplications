namespace ModernWebStore.Domain.Commands.CategoryCommands
{
    public class DeleteCategoryCommand
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }
    }
}
