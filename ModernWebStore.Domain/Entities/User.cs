using ModernWebStore.Domain.Scopes;
using ModernWebStore.SharedKernel.Helpers;

namespace ModernWebStore.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string  Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(string email, string password, bool isAdmin)
        {
            this.Email = email;
            this.Password = StringHelper.Encrypt(password);
            this.IsAdmin = isAdmin;
        }

        public void Register()
        {
            this.RegisterUserScopeIsValid();
        }

        public void GrantAdmin()
        {
            this.IsAdmin = true;
        }

        public void RevokeAdmin()
        {
            this.IsAdmin = false;
        }
    }
}
