using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBooksAPI.Comics
{
    public class Comic
    {
        public int ComicId { get; set; }
        public string Name { get; set; }
        public uint Size { get; set; }
    }
}
