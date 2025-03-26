using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookClub_Data;
using System;

namespace BookClub_DataTests
{
    [TestClass]
    public class BookClubTests
    {
        [TestMethod]
        public void BookClubIdTest()
        {
            BookClub bookClub = new BookClub();
            bookClub.Id = 1;
            Assert.AreEqual(1, bookClub.Id);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookClub.Id = -1);
        }

        [TestMethod]
        public void BookIdTest()
        {
            BookClub bookClub = new BookClub();
            bookClub.BookId = 1;
            Assert.AreEqual(1, bookClub.BookId);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookClub.BookId = -1);
        }

        [TestMethod]
        public void ClubNameTest()
        {
            BookClub bookClub = new BookClub();
            bookClub.ClubName = "Test Club";
            Assert.AreEqual("Test Club", bookClub.ClubName);
            Assert.ThrowsException<ArgumentNullException>(() => bookClub.ClubName = null);
        }

        [TestMethod]
        public void CreatorUserIdTest()
        {
            BookClub bookClub = new BookClub();
            bookClub.CreatorUserId = 1;
            Assert.AreEqual(1, bookClub.CreatorUserId);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookClub.CreatorUserId = -1);
        }
    }
}



