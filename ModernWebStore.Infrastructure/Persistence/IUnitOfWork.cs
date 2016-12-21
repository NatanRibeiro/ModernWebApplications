using System;

namespace ModernWebStore.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
