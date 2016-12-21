using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Infrastructure.Persistence.DataContext;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModernWebStore.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private StoreDataContext _context;

        public CategoryRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Create(Category category)
            => _context.Categories.Add(category);

        public void Delete(Category category)
            => _context.Categories.Remove(category);

        public List<Category> Get()
            => _context.Categories.ToList();

        public Category Get(int id)
            => _context.Categories.Find(id);

        public List<Category> Get(int skip, int take)
            => _context.Categories.OrderBy(x=> x.Title).Skip(skip).Take(take).ToList();

        public void Update(Category category)
            => _context.Entry<Category>(category).State = EntityState.Modified;
    }
}
