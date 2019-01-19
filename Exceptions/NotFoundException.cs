using System;

namespace ComicBooksAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string type) : base($"{type} not found")
        {
        }
    }
}