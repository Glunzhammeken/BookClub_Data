using Microsoft.EntityFrameworkCore;

namespace BookClub_Data
{
    public class BookClubDbContext : DbContext
    {
        public BookClubDbContext(DbContextOptions<BookClubDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookClubDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<BookClub>().HasKey(bc => bc.Id);
            modelBuilder.Entity<Message>().HasKey(m => m.Id);

            modelBuilder.Entity<BookClub>()
                .HasMany(bc => bc.Messages)
                .WithOne(m => m.BookClub)
                .HasForeignKey(m => m.BookClubId);

            modelBuilder.Entity<BookClub>()
                .HasMany(bc => bc.Members)
                .WithMany(u => u.BookClubs)
                .UsingEntity<Dictionary<string, object>>(
                    "BookClubUsers",
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.HasOne<BookClub>().WithMany().HasForeignKey("BookClubId"));

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<BookClub>()
                .HasOne(bc => bc.Creator)
                .WithMany()
                .HasForeignKey(bc => bc.CreatorUserId);

            modelBuilder.Entity<BookClub>()
                .HasOne(bc => bc.Book)
                .WithMany()
                .HasForeignKey(bc => bc.BookId);
        }
    }
}
