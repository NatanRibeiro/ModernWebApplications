using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Domain.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterUserScopeIsValid(this User user)
        {
            return AssertionConcern.IsValid
                (
                    AssertionConcern.AssertNotEmpty(user.Email, "The e-mail is obrigatory!"),
                    AssertionConcern.AssertNotEmpty(user.Password, "The password is obrigatory!")
                );
        }

        public static bool AuthenticateUserScopeIsValid(this User user, string email, string encryptedPassword)
        {
            return AssertionConcern.IsValid
                (
                    AssertionConcern.AssertNotEmpty(email, "The e-mail is obrigatory!"),
                    AssertionConcern.AssertNotEmpty(encryptedPassword, "The password is obrigatory!"),
                    AssertionConcern.AssertAreEquals(user.Email, email, "The user or e-mail is invalid!"),
                    AssertionConcern.AssertAreEquals(user.Password, encryptedPassword, "The password is obrigatory!")
                );
        }
    }
}
