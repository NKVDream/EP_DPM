using Microsoft.EntityFrameworkCore;
using Lib_API.Models;

namespace Lib_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Author>().ToTable("authors");
            modelBuilder.Entity<Genre>().ToTable("genres");
            modelBuilder.Entity<Reader>().ToTable("readers");
            modelBuilder.Entity<Loan>().ToTable("loans");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.BookId).HasColumnName("book_id");
                entity.Property(b => b.AuthorId).HasColumnName("author_id");
                entity.Property(b => b.GenreId).HasColumnName("genre_id");
                entity.Property(b => b.Title).HasColumnName("title");
                entity.Property(b => b.PublishYear).HasColumnName("publish_year");
                entity.Property(b => b.Available).HasColumnName("available");

                entity.HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId);

                entity.HasOne(b => b.Genre)
                    .WithMany(g => g.Books)
                    .HasForeignKey(b => b.GenreId);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(l => l.LoanId).HasColumnName("loan_id");
                entity.Property(l => l.BookId).HasColumnName("book_id");
                entity.Property(l => l.ReaderId).HasColumnName("reader_id");
                entity.Property(l => l.LoanDate).HasColumnName("loan_date");
                entity.Property(l => l.ReturnDate).HasColumnName("return_date");

                entity.HasOne(l => l.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(l => l.BookId);

                entity.HasOne(l => l.Reader)
                    .WithMany(r => r.Loans)
                    .HasForeignKey(l => l.ReaderId);
            });
        }
    }
}
