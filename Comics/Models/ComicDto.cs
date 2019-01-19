using System;

namespace ComicBooksAPI.Comics.Models
{
    public class ComicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Issue { get; set; }
        public int Size { get; set; }
        public string Writer { get; set; }
        public DateTime Release { get; set; }
        public string Cover { get; set; }
        public Guid? TitleId { get; set; }
    }
}
