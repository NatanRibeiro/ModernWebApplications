using System.Collections.Generic;

namespace ModernWebStore.Domain.Commands.OrderCommands
{
    public class CreateOrderCommand
    {
        public IList<CreateOrderItemCommand> OrderItems { get; set; }

        public CreateOrderCommand(IList<CreateOrderItemCommand> orderItems)
        {
            this.OrderItems = orderItems;
        }
    }
}
