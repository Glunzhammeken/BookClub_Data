using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookClub_Data;
using System;

namespace BookClub_DataTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserIdTest()
        {
            User user = new User();
            user.Id = 1;
            Assert.AreEqual(1, user.Id);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => user.Id = -1);
        }

        [TestMethod]
        public void UserNameTest()
        {
            User user = new User();
            user.UserName = "testuser";
            Assert.AreEqual("testuser", user.UserName);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => user.UserName = "abc");
            Assert.ThrowsException<ArgumentNullException>(() => user.UserName = null);
            Assert.ThrowsException<ArgumentException>(() => user.UserName = "invalid@name");
        }

        [TestMethod]
        public void EmailTest()
        {
            User user = new User();
            user.Email = "test@example.com";
            Assert.AreEqual("test@example.com", user.Email);
            Assert.ThrowsException<ArgumentNullException>(() => user.Email = null);
            Assert.ThrowsException<ArgumentException>(() => user.Email = "invalid-email");
        }

        [TestMethod]
        public void PasswordHashTest()
        {
            User user = new User();
            user.PasswordHash = "Valid1Password!";
            Assert.IsNotNull(user.PasswordHash);
            Assert.ThrowsException<ArgumentNullException>(() => user.PasswordHash = null);
            Assert.ThrowsException<ArgumentException>(() => user.PasswordHash = "Short1!");
            Assert.ThrowsException<ArgumentException>(() => user.PasswordHash = "lowercase1!");
            Assert.ThrowsException<ArgumentException>(() => user.PasswordHash = "UPPERCASE1!");
            Assert.ThrowsException<ArgumentException>(() => user.PasswordHash = "NoNumber!");
            Assert.ThrowsException<ArgumentException>(() => user.PasswordHash = "NoSpecial1");
        }

        [TestMethod]
        public void RoleTest()
        {
            User user = new User();
            user.Role = "admin";
            Assert.AreEqual("admin", user.Role);
            user.Role = "participant";
            Assert.AreEqual("participant", user.Role);
            Assert.ThrowsException<ArgumentNullException>(() => user.Role = null);
            Assert.ThrowsException<ArgumentException>(() => user.Role = "invalidrole");
        }
    }
}


