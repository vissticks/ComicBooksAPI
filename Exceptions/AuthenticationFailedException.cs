using System;

namespace ComicBooksAPI.Exceptions
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException(string message) : base(message)
        {
        }
    }
}