using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ComicBooksAPI.DAL
{
    public abstract class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly ComicsContext _context;
        
        public GenericService(ComicsContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(Guid id)
        {
            var obj = await _context.FindAsync<T>(id);
            if (obj != null)
            {
                _context.Remove(obj);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}