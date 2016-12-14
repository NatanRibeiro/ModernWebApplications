using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Validation;

namespace ModernWebStore.Domain.Scopes
{
    public static class OrderScopes
    {
        public static bool PlaceOrderScopeIsValid(this Order order)
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertIsGreaterThan(order.OrderItems.Count, 0, "You don't have products!")
            );
        }
    }
}
