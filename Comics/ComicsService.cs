using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBooksAPI.DAL;
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
    }
}