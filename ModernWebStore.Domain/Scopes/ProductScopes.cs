using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Validation;

namespace ModernWebStore.Domain.Scopes
{
    public static class ProductScopes
    {
        public static bool RegisterProductScopeIsValid(this Product product)
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertNotNull(product.Title, "The title from product is obrigatory!"),
                AssertionConcern.AssertNotNull(product.Description, "The description from product is obrigatory!"),
                AssertionConcern.AssertIsGreaterThan(product.CategoryId, 0, "The category from product is obrigatory!"),
                AssertionConcern.AssertIsGreaterThan(product.Price, 0, "The price from product should be greater than zero!"),
                AssertionConcern.AssertIsGreaterThan(product.QuantityOnHand, 0, "The quantity from product should be greater than zero!")
            );
        }

        public static bool UpdateInfoScopeIsValid(this Product product, string title, string description, int category)
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertNotNull(title, "The title is obrigatory!"),
                AssertionConcern.AssertNotNull(title, "The description is obrigatory!"),
                AssertionConcern.AssertIsGreaterThan(category, 0, "The category should be greater than zero!")
            );
        }

        public static bool UpdateQuantityOnHandScopeIsValid(this Product product, int amount)
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertIsGreaterOrEqualThan(amount, 0, "The quantity should be greater than zero!")
            );
        }

        public static bool UpdatePriceScopeIsValid(this Product product, decimal price)
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertIsGreaterThan(price, 0, "The price should be grater than zero!")
            );
        }
    }
}
