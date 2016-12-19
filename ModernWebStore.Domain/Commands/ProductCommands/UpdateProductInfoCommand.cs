namespace ModernWebStore.Domain.Commands.ProductCommands
{
    public class UpdateProductInfoCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public UpdateProductInfoCommand(int id, string title, string description, int categoryId)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.CategoryId = categoryId;
        }
    }
}
