using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infrastructure.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private StoreDataContext _context;

        public UserRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Register(User user)
            => _context.Users.Add(user);

        public User Authenticate(string email, string password)
            => _context.Users.Where(UserSpecs.AuthenticateUser(email, password)).FirstOrDefault();

        public User GetByEmail(string email)
            => _context.Users.Where(UserSpecs.GetByEmail(email)).FirstOrDefault();

    }
}
