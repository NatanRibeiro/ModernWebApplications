using ModernWebStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernWebStore.Infrastructure.Persistence.Map
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");

            HasKey(x => x.Id);
            HasRequired(x => x.Category);
            Property(x => x.Description).HasMaxLength(1024).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.QuantityOnHand).IsRequired();
            Property(x => x.Title).IsRequired();
            Property(x => x.Image);
        }
    }
}
