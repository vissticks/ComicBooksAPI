using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ComicBooksAPI.Comics.Models;

namespace ComicBooksAPI.Titles.Models
{
    public class Title
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public IEnumerable<Comic> Issues { get; set; }
    }
}
