using ModernWebStore.Domain.Scopes;

namespace ModernWebStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        public string Image { get; private set; }

        public Product()
        {
            
        }

        public Product(string title, string description, decimal price, int quantityOnHand, int categoryId, string image)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.QuantityOnHand = quantityOnHand;
            this.CategoryId = categoryId;
            this.Image = image;
        }

        public void UpdateInfo(string title, string description, int category, string image)
        {
            if (!this.UpdateInfoScopeIsValid(title, description, category))
                return;

            this.Title = title;
            this.Description = description;
            this.CategoryId = category;
            this.Image = image;
        }

        public void UpdateQuantityOnHand(int amount)
        {
            if (!this.UpdateQuantityOnHandScopeIsValid(amount))
                return;

            this.QuantityOnHand = amount;
        }

        public void UpdatePrice(decimal price)
        {
            if (!this.UpdatePriceScopeIsValid(price))
                return;

            this.Price = price;
        }

        public void UpdateImage(string image)
        {
            if (!this.UpdateImageScopeIsValid(image))
                return;

            this.Image = image;
        }


        public void Register()
        {
            this.RegisterProductScopeIsValid();
        }
    }
}
