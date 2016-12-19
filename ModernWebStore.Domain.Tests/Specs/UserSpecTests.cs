using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Helpers;
using ModernWebStore.Domain.Specs;
using System.Linq;

namespace ModernWebStore.Domain.Tests.Specs
{
    [TestClass]
    public class UserSpecTests
    {
        private List<User> _users;

        public UserSpecTests()
        {
            this._users = new List<User>();
            this._users.Add(new User("teste1@hotmail.com", StringHelper.Encrypt("123456"), true));
            this._users.Add(new User("teste2@hotmail.com", StringHelper.Encrypt("123456"), true));
            this._users.Add(new User("teste3@hotmail.com", StringHelper.Encrypt("123456"), true));
            this._users.Add(new User("teste4@hotmail.com", StringHelper.Encrypt("123456"), true));
            this._users.Add(new User("natan@hotmail.com", StringHelper.Encrypt("123456"), true));
        }

        [TestMethod]
        [TestCategory("User Specs - Authenticate")]
        public void ShouldAuthenticate()
        {
            var exp = UserSpecs.AuthenticateUser("natan@hotmail.com", "123456");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs - Authenticate")]
        public  void ShouldNotAuthenticateWhenEmailIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("natan@gmail.com", "123456");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs - Authenticate")]
        public void ShouldNotAuthenticateWhenPasswordIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("natan@hotmail.com", "012345");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }
    }
}
