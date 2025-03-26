using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookClub_Data;
using System;

namespace BookClub_DataTests
{
    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void MessageIdTest()
        {
            Message message = new Message();
            message.MessageId = 1;
            Assert.AreEqual(1, message.MessageId);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => message.MessageId = -1);
        }

        [TestMethod]
        public void BookClubIdTest()
        {
            Message message = new Message();
            message.BookClubId = 1;
            Assert.AreEqual(1, message.BookClubId);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => message.BookClubId = -1);
        }

        [TestMethod]
        public void UserIdTest()
        {
            Message message = new Message();
            message.UserId = 1;
            Assert.AreEqual(1, message.UserId);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => message.UserId = -1);
        }

        [TestMethod]
        public void MessageContentTest()
        {
            Message message = new Message();
            message.MessageContent = "Test Message";
            Assert.AreEqual("Test Message", message.MessageContent);
            Assert.ThrowsException<ArgumentNullException>(() => message.MessageContent = null);
        }

        [TestMethod]
        public void TimestampTest()
        {
            Message message = new Message();
            DateTime now = DateTime.Now;
            message.Timestamp = now;
            Assert.AreEqual(now, message.Timestamp);
        }
    }
}



