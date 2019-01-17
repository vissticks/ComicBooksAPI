using ComicBooksAPI.Comics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBooksAPI
{
    public class ComicsContext : DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Comic> Comics { get; set; }
    }
}
