using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Helpers;
using System;
using System.Linq.Expressions;

namespace ModernWebStore.Domain.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> AuthenticateUser(string email, string password)
        => x => x.Email == email && x.Password == StringHelper.Encrypt(password);

        public static Expression<Func<User, bool>> GetByEmail(string email)
        => x => x.Email == email;
    }
}
