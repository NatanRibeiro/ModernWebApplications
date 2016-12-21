using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infrastructure.Persistence.DataContext;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModernWebStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private StoreDataContext _context;

        public ProductRepository(StoreDataContext context)
        {
           _context = context;
        }

        public void Create(Product product)
            => _context.Products.Add(product);

        public void Delete(Product product)
            => _context.Products.Remove(product);

        public List<Product> Get()
            => _context.Products.ToList();

        public Product Get(int id)
            => _context.Products.Find(id);

        public List<Product> Get(int skip, int take)
            => _context.Products.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();

        public List<Product> GetProductsInStock()
            => _context.Products.Where(ProductSpecs.GetProductsInStock()).ToList();

        public List<Product> GetProductsOutOfStock()
            => _context.Products.Where(ProductSpecs.GetProductsOutOfStock()).ToList();

        public void Update(Product product)
            => _context.Entry<Product>(product).State = EntityState.Modified;
    }
}
