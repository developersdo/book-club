using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DevDo.BookClub.Tests.Models
{
    public class BookTest
    {
        public class Class1
        {
            [Fact]
            public void CanConstructBook()
            {
                var book = new DevDo.BookClub.Models.Book();
            }

            [Fact]
            public void BookHasNecessaryProperties()
            {
                var book = new DevDo.BookClub.Models.Book {
                    Title = "The Pragmatic Programmer",
                    Author = "Andy Hunt",
                    ISBN = "020161622X",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg"
                };
            }
        }
    }
}