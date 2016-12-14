using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Validation;

namespace ModernWebStore.Domain.Scopes
{
    public static class OrderItemScopes
    {
        public static bool RegisterOrderItemScopeIsValid(this OrderItem orderItem)
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertIsGreaterThan(orderItem.Price, 0, "Invalid Price!"),
                AssertionConcern.AssertIsGreaterThan(orderItem.ProductId, 0, "Invalid Product!"),
                AssertionConcern.AssertIsGreaterThan(orderItem.Quantity, 0, "Invalid Quantity!")
            );
        }

        public static bool AddProductScopeIsValid(this OrderItem orderItem, Product product, decimal price, int quantity)
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertIsGreaterOrEqualThan((product.QuantityOnHand - quantity), 0, "Product out of stock: " + product.Title),
                AssertionConcern.AssertIsGreaterThan(price, 0, "Price should be greater than 0!"),
                AssertionConcern.AssertIsGreaterThan(quantity, 0, "Quantity should be greater than 0!")
            );
        }
    }
}
