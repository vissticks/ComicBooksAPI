using System;
using System.Collections.Generic;
using ComicBooksAPI.Comics.Models;

namespace ComicBooksAPI.Titles.Models
{
    public class TitleExtendedDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ComicDto> Issues { get; set; }
    }
}
