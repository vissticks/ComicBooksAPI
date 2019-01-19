using System;
using System.ComponentModel.DataAnnotations;
using ComicBooksAPI.Titles;
using ComicBooksAPI.Titles.Models;

namespace ComicBooksAPI.Comics.Models
{
    public class Comic
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public int? Issue { get; set; }
        
        public int Size { get; set; }
        
        public string Writer { get; set; }
        
        public DateTime Release { get; set; }
        
        public string Cover { get; set; }
        
        public Guid? TitleId { get; set; }
        public Title Title { get; set; }
    }
}
