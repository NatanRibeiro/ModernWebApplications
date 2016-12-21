using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infrastructure.Persistence.Map
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItem");

            HasKey(x => x.Id);
            HasRequired(x => x.Order);
            HasRequired(x => x.Product);
            Property(x => x.Price).IsRequired();
            Property(x => x.Quantity).IsRequired();
        }
    }
}
