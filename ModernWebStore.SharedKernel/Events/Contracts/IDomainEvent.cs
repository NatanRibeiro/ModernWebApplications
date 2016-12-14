using System;

namespace ModernWebStore.SharedKernel.Events.Contracts
{
    public interface IDomainEvent
    {
        DateTime DateOcurred { get; }
    }
}
