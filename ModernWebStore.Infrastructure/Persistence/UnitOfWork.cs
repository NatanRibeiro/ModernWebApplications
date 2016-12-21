using ModernWebStore.Infrastructure.Persistence.DataContext;

namespace ModernWebStore.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private StoreDataContext _context;

        public UnitOfWork(StoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
            => _context.SaveChanges();

        public void Dispose()
            => Dispose(true);

        private void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
