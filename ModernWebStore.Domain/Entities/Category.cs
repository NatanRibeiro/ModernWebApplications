using ModernWebStore.Domain.Scopes;

namespace ModernWebStore.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public Category(string title)
        {
            this.Title = title;
        }

        public void Register()
        {
            if (!this.CreateCategoryScopeIsValid())
                return;
        }

        public void UpdateTitle(string title)
        {
            if (!this.UpdateCategoryScopeIsValid(title))
                return;

            this.Title = title;
        }
    }
}
