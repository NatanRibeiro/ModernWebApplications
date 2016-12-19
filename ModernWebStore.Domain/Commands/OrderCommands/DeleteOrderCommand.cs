namespace ModernWebStore.Domain.Commands.OrderCommands
{
    public class DeleteOrderCommand
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            this.Id = id;
        }
    }
}
