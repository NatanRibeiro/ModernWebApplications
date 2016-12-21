using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infrastructure.Persistence.Map
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");

            HasKey(x => x.Id);
            HasMany(x => x.OrderItems).WithRequired(x => x.Order);
            HasRequired(x => x.User);
            Ignore(x => x.Total);
            Property(x => x.Date).IsRequired();
            Property(x => x.Status).IsRequired();
        }
    }
}
