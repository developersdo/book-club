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

            [Fact]
            public void BookDoesntHaveTitle_ReturnsValidationError()
            {
                var book = new DevDo.BookClub.Models.Book
                {
                    Title = null,
                    Author = "Andy Hunt",
                    ISBN = "020161622X",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg"
                };
                var ValidationResult = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(book, new ValidationContext(book), ValidationResult, true);
                Assert.False(actual, "Expected validation to fail.");
            }

            [Fact]
            public void BookDoesntHaveAuthor_ReturnsValidationError()
            {
                var book = new DevDo.BookClub.Models.Book
                {
                    Title = "The Pragmatic Programmer",
                    Author = null,
                    ISBN = "020161622X",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg"
                };
                var ValidationResult = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(book, new ValidationContext(book), ValidationResult, true);
                Assert.False(actual, "Expected validation to fail.");
            }

            [Fact]
            public void BookDoesntHaveISBN_ReturnsValidationError()
            {
                var book = new DevDo.BookClub.Models.Book
                {
                    Title = "The Pragmatic Programmer",
                    Author = "Andy Hunt",
                    ISBN = null,
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/41BKx1AxQWL._SX258_BO1,204,203,200_.jpg"
                };
                var ValidationResult = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(book, new ValidationContext(book), ValidationResult, true);
                Assert.False(actual, "Expected validation to fail.");
            }

            [Fact]
            public void BookDoesntHaveCover_ReturnsValidationError()
            {
                var book = new DevDo.BookClub.Models.Book
                {
                    Title = "The Pragmatic Programmer",
                    Author = "Andy Hunt",
                    ISBN = "020161622X",
                    CoverUrl = null
                };
                var ValidationResult = new List<ValidationResult>();
                var actual = Validator.TryValidateObject(book, new ValidationContext(book), ValidationResult, true);
                Assert.False(actual, "Expected validation to fail.");
            }
        }
        }
    }