using ModernWebStore.Domain.Commands.CategoryCommands;
using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface ICategoryApplicationService
    {
        List<Category> Get();
        List<Category> Get(int skip, int take);
        Category Get(int id);
        Category Create(CreateCategoryCommand command);
        Category Update(UpdateCategoryCommand command);
        Category Delete(DeleteCategoryCommand command);
    }
}
