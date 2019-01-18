using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComicBooksAPI.DAL
{
    public interface IGenericService<T> where T : class
    {
        Task<T> Create(T obj);
        Task Delete(Guid id);
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}