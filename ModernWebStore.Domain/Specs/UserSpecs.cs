using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Helpers;
using System;
using System.Linq.Expressions;

namespace ModernWebStore.Domain.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> AuthenticateUser(string email, string password)
        {
            var strEncryptedPassword = StringHelper.Encrypt(password);
            return x => x.Email == email && x.Password == strEncryptedPassword;
        }

        public static Expression<Func<User, bool>> GetByEmail(string email)
        => x => x.Email == email;
    }
}
