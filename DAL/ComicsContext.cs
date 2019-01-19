using ComicBooksAPI.Comics;
using ComicBooksAPI.Comics.Models;
using ComicBooksAPI.Titles;
using ComicBooksAPI.Titles.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBooksAPI.DAL
{
    public class ComicsContext : DbContext
    {
        public ComicsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>()
                .HasOne(c => c.Title)
                .WithMany(t => t.Issues)
                .HasForeignKey(c => c.TitleId);
        }

        public DbSet<Comic> Comics { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
