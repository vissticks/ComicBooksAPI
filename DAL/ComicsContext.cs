using ComicBooksAPI.Comics;
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

        public DbSet<Comic> Comics { get; set; }
    }
}
