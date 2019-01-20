using Microsoft.AspNetCore.Identity;

namespace ComicBooksAPI.Users.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
    }
}