using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBooksAPI.Comics.Models;
using ComicBooksAPI.DAL;
using ComicBooksAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ComicBooksAPI.Comics
{
    public class ComicsService : GenericService<Comic>
    {
        private readonly ComicsContext _context;

        public ComicsService(ComicsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Comic> GetComic(Guid id)
        {
            var comic = await _context.Comics
                .Include(c => c.Title)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comic == null) throw new NotFoundException($"Comic with id '{id}'");
            return comic;
        }

        public async Task<IEnumerable<Comic>> GetAllComics()
        {
            return await _context.Comics
                .Include(c => c.Title)
                .ToListAsync();
        }
    }
}