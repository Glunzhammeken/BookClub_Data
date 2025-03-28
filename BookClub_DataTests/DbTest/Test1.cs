using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookClub_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookClub_DataTests
{
    [TestClass]
    public class UserTests1
    {
        private BookClubDbContext _dbContext;

        [TestInitialize]
        public void Init()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookClubDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookClubDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            // Assign the correct context to the class-level variable
            _dbContext = new BookClubDbContext(optionsBuilder.Options);

            // Ensure the database is cleared before each test
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        [TestMethod]
        public void CanAddUserToDatabase()
        {
            var user = new User
            {
                UserName = "TestUser",
                Email = "testuser@example.com",
                PasswordHash = "TestPassword123!",
                Role = "admin"
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            Assert.AreEqual(1, _dbContext.Users.Count());
            var retrievedUser = _dbContext.Users.First();
            Assert.AreEqual("TestUser", retrievedUser.UserName);
            Assert.AreEqual("testuser@example.com", retrievedUser.Email);
            Assert.AreEqual("admin", retrievedUser.Role);
        }

        [TestMethod]
        public void CanAddBookClubWithUser()
        {
            var user = new User
            {
                UserName = "TestUser",
                Email = "testuser@example.com",
                PasswordHash = "TestPassword123!",
                Role = "admin"
            };

            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                Description = "Test Description",
                UploadDate = DateTime.Now,
                FilePath = "test/path"
            };

            var bookClub = new BookClub
            {
                Book = book,
                ClubName = "Test Club",
                Creator = user
            };

            bookClub.Members.Add(user);

            _dbContext.Users.Add(user);
            _dbContext.Books.Add(book);
            _dbContext.BookClubs.Add(bookClub);
            _dbContext.SaveChanges();

            Assert.AreEqual(1, _dbContext.BookClubs.Count());
            var retrievedBookClub = _dbContext.BookClubs.Include(bc => bc.Members).First();
            Assert.AreEqual("Test Club", retrievedBookClub.ClubName);
            Assert.AreEqual(1, retrievedBookClub.Members.Count);
            Assert.AreEqual("TestUser", retrievedBookClub.Members.First().UserName);
        }
    }
}
