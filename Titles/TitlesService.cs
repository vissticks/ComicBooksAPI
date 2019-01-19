using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicBooksAPI.Comics.Models;
using ComicBooksAPI.DAL;
using ComicBooksAPI.Exceptions;
using ComicBooksAPI.Titles.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBooksAPI.Titles
{
    public class TitlesService : GenericService<Title>
    {
        private readonly ComicsContext _context;

        public TitlesService(ComicsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Title> GetTitle(Guid id)
        {
            var title = await _context.Titles
                .Include(t => t.Issues)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (title == null) throw new NotFoundException($"Title with id '{id}'");
            return title;
        }

        public async Task<IEnumerable<Title>> GetAllTitles()
        {
            return await _context.Titles
                .Include(t => t.Issues)
                .ToListAsync();
        }
    }
}