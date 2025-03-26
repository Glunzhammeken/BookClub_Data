using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookClub_Data;
using System;

namespace BookClub_DataTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void BookIdTest()
        {
            Book book = new Book();
            book.BookId = 1;
            Assert.AreEqual(1, book.BookId);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.BookId = -1);
        }

        [TestMethod]
        public void TitleTest()
        {
            Book book = new Book();
            book.Title = "Test Title";
            Assert.AreEqual("Test Title", book.Title);
            Assert.ThrowsException<ArgumentNullException>(() => book.Title = null);
        }

        [TestMethod]
        public void AuthorTest()
        {
            Book book = new Book();
            book.Author = "Test Author";
            Assert.AreEqual("Test Author", book.Author);
            Assert.ThrowsException<ArgumentNullException>(() => book.Author = null);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            Book book = new Book();
            book.Description = "Test Description";
            Assert.AreEqual("Test Description", book.Description);
            Assert.ThrowsException<ArgumentNullException>(() => book.Description = null);
        }

        [TestMethod]
        public void FilePathTest()
        {
            Book book = new Book();
            string validFilePath = System.IO.Path.GetTempFileName(); // Create a temporary file for testing
            book.FilePath = validFilePath;
            Assert.AreEqual(validFilePath, book.FilePath);
            Assert.ThrowsException<ArgumentException>(() => book.FilePath = "invalid/path/to/file.pdf");
        }
    }
}