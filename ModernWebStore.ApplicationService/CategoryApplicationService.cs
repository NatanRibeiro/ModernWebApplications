using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infrastructure.Persistence;
using System.Collections.Generic;
using ModernWebStore.Domain.Commands.CategoryCommands;
using ModernWebStore.Domain.Entities;

namespace ModernWebStore.ApplicationService
{
    public class CategoryApplicationService : BaseApplicationService, ICategoryApplicationService
    {
        private ICategoryRepository _repository;

        public CategoryApplicationService(ICategoryRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public Category Create(CreateCategoryCommand command)
        {
            var category = new Category(command.Title);
            category.Register();
            _repository.Create(category);

            if (Commit())
                return category;

            return null;
        }

        public Category Update(UpdateCategoryCommand command)
        {
            var category = _repository.Get(command.Id);
            category.UpdateTitle(command.Title);
            _repository.Update(category);

            if (Commit())
                return category;

            return null;
        }

        public Category Delete(DeleteCategoryCommand command)
        {
            var category = _repository.Get(command.Id);
            _repository.Delete(category);

            if (Commit())
                return category;

            return null;
        }

        public List<Category> Get()
        {
            return _repository.Get();
        }

        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Category> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }
    }
}
