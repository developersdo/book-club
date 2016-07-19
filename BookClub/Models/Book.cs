using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDo.BookClub.Models
{
    public class Book
    {
       
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string CoverUrl { get; set; }
    }
}
