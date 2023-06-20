using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastracture.IntegrationTests
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasKey(x=>x.Id);
            modelBuilder.Entity<Book>()
                .HasMany(x => x.BookAuthors)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Author>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.BookAuthors)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(x=>x.Book)
                .WithMany(x=>x.BookAuthors)
                .HasForeignKey(x=>x.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(x => x.Author)
                .WithMany(x => x.BookAuthors)
                .HasForeignKey(x => x.AuthorId);

        }
    }
}