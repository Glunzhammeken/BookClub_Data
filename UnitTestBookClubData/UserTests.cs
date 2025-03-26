using System;
using Xunit;
using BookClub_Data;

namespace BookClub_Tests
{
    public class UserTests
    {
        [Fact]
        public void UserName_ShouldThrowException_WhenNull()
        {
            var user = new User();
            Assert.Throws<ArgumentNullException>(() => user.UserName = null);
        }

        [Fact]
        public void UserName_ShouldThrowException_WhenTooShort()
        {
            var user = new User();
            Assert.Throws<ArgumentOutOfRangeException>(() => user.UserName = "abc");
        }

        [Fact]
        public void UserName_ShouldThrowException_WhenInvalidCharacters()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.UserName = "abc@");
        }

        [Fact]
        public void Email_ShouldThrowException_WhenInvalidFormat()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.Email = "invalid-email");
        }

        [Fact]
        public void PasswordHash_ShouldThrowException_WhenTooShort()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.PasswordHash = "Short1!");
        }

        [Fact]
        public void PasswordHash_ShouldThrowException_WhenMissingUppercase()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.PasswordHash = "lowercase1!");
        }

        [Fact]
        public void PasswordHash_ShouldThrowException_WhenMissingLowercase()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.PasswordHash = "UPPERCASE1!");
        }

        [Fact]
        public void PasswordHash_ShouldThrowException_WhenMissingNumber()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.PasswordHash = "NoNumber!");
        }

        [Fact]
        public void PasswordHash_ShouldThrowException_WhenMissingSpecialCharacter()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.PasswordHash = "NoSpecial1");
        }

        [Fact]
        public void Role_ShouldThrowException_WhenInvalid()
        {
            var user = new User();
            Assert.Throws<ArgumentException>(() => user.Role = "invalidrole");
        }
    }
}

