namespace ModernWebStore.Domain.Commands.ProductCommands
{
    public class DeleteProductCommand
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            this.Id = id;
        }
    }
}
