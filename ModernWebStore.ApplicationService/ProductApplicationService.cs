using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infrastructure.Persistence;
using System.Collections.Generic;
using ModernWebStore.Domain.Commands.ProductCommands;
using ModernWebStore.Domain.Entities;

namespace ModernWebStore.ApplicationService
{
    public class ProductApplicationService : BaseApplicationService, IProductApplicationService
    {
        private IProductRepository _repository;

        public ProductApplicationService(IProductRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public Product Create(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Description, command.Price, command.QuantityOnHand, command.CategoryId);
            product.Register();
            _repository.Create(product);

            if (Commit())
                return product;

            return null;
        }

        public Product UpdateBasicInformation(UpdateProductInfoCommand command)
        {
            var product = _repository.Get(command.Id);
            product.UpdateInfo(command.Title, command.Description, command.CategoryId);
            _repository.Update(product);

            if (Commit())
                return product;

            return null;
        }

        public Product Delete(DeleteProductCommand command)
        {
            var product = _repository.Get(command.Id);
            _repository.Delete(product);

            if (Commit())
                return product;

            return null;
        }

        public List<Product> Get()
        {
            return _repository.GetProductsInStock();
        }

        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Product> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public List<Product> GetOutOfStock()
        {
            return _repository.GetProductsOutOfStock();
        }
    }
}
