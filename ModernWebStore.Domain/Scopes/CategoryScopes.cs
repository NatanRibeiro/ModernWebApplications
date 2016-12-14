using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Validation;

namespace ModernWebStore.Domain.Scopes
{
    public static class CategoryScopes
    {
        public static bool CreateCategoryScopeIsValid(this Category category)
        {
            return AssertionConcern.IsValid
                (
                    AssertionConcern.AssertNotEmpty(category.Title, "The title is obrigatory!"),
                    AssertionConcern.AssertLength(category.Title, 3, 20, "The minimum lenth is 3!")
                );
        }

        public static bool UpdateCategoryScopeIsValid(this Category category, string title)
        {
            return AssertionConcern.IsValid
                (
                    AssertionConcern.AssertNotEmpty(title, "The title is obrigatory!")
                );
        }
    }
}
