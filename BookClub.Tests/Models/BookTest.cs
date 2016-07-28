using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                var ValidationResult = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(book, new ValidationContext(book), ValidationResult, true);
                Assert.True(actual, "Expected validation to pass.");
            }

            [Fact]
            public void BookHasAnISBNWithMoreThanThirteenDigits_ReturnsValidationError()
            {
                var book = new DevDo.BookClub.Models.Book
                {
                    Title = "The Pragmatic Programmer",
                    Author = "Andy Hunt",
                    ISBN = "020161622X9409",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg"
                };
                var ValidationResult = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(book, new ValidationContext(book), ValidationResult, true);
                Assert.False(actual, "Expected validation to fail.");
            }

            [Theory()]
            [InlineData(null, "Andy Hunt", "020161622X9409", "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg")]
            [InlineData("The Pragmatic Programmer", null, "020161622X9409", "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg")]
            [InlineData("The Pragmatic Programmer", "Andy Hunt", null, "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg")]
            [InlineData("The Pragmatic Programmer", "Andy Hunt", "020161622X9409", null)]
            public void BookDoestHaveNecessaryProperties_ReturnsValidationError(string title, string author, string isbn, string coverURL)
            {
                var book = new DevDo.BookClub.Models.Book
                {
                    Title = title,
                    Author = author,
                    ISBN = isbn,
                    CoverUrl = coverURL
                };
                var ValidationResult = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(book, new ValidationContext(book), ValidationResult, true);
                Assert.False(actual, "Expected validation to fail.");
            }           
            }
        }
        }    