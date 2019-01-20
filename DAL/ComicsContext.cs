using ComicBooksAPI.Comics.Models;
using ComicBooksAPI.Titles.Models;
using ComicBooksAPI.Users.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicBooksAPI.DAL
{
    public class ComicsContext : IdentityDbContext<User>
    {
        public ComicsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Comic>()
                .HasOne(c => c.Title)
                .WithMany(t => t.Issues)
                .HasForeignKey(c => c.TitleId);
        }

        public DbSet<Comic> Comics { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
