using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Training_Center_Task_3;

namespace Training_Center_Task_3_Unit_Tests
{
    public class Tests
    {
        private List<Author> _authors;
        private Book _book;
        private Catalog _catalog;
        private string _isbn = "123-4-56-789101-1";

        [SetUp]
        public void Setup()
        {
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            _authors = new List<Author>();
            _authors.Add(new Author("Ivo", "Igov"));

            _book = new Book(_isbn, "Title 2", date, _authors);

            _catalog = new Catalog();
            ;
        }

        [Test]
        public void Ctor_CreateBookValidData()
        {
            string title = "Title 2";
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            Book book = new Book(_isbn, title, date, _authors);
            Assert.AreEqual(book.ISBN, _isbn);
            Assert.AreEqual(book.Title, "Title 2");
            Assert.AreEqual(book.Date, date);
            Assert.AreEqual(book.Authors.Count, 1);
        }

        [Test]
        public void Ctor_CreateBookInvalidISBN()
        {
            string title = "Title 2";
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            Assert.Throws<Exception>(() => new Book(_isbn, title, date, _authors));
        }

        [Test]
        public void Ctor_CreateBookInvalidTitleEmpty()
        {
            string title = "";
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            Assert.Throws<ArgumentException>(() => new Book(_isbn, title, date, _authors));
        }

        [Test]
        public void Ctor_CreateBookInvalidDateFormat()
        {
            string title = "Title 2";

            Assert.Throws<FormatException>(() => DateOnly.ParseExact("2022-13-23", "yyyy-MM-dd"));
        }

        [Test]
        public void Ctor_CreateAuthorFirstNameEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Author("", "Igov"));
        }

        [Test]
        public void Ctor_CreateAuthorLastNameEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Author("Ivo", ""));
        }

        [Test]
        public void Ctor_CreateAuthorFirstNameTooLong()
        {
            Assert.Throws<Exception>(() => new Author(
                "verylongauthornameverylongauthornameverylongauthornameverylongauthorname" +
                "verylongauthornameverylongauthornameverylongauthornameverylongauthorname" +
                "verylongauthornameverylongauthornameverylongauthornamever", "Igov"));
        }

        [Test]
        public void Ctor_CreateAuthorLastNameTooLong()
        {
            Assert.Throws<Exception>(() => new Author(
                "Ivo", "verylongauthornameverylongauthornameverylongauthornameverylongauthorname" +
                "verylongauthornameverylongauthornameverylongauthornameverylongauthorname" +
                "verylongauthornameverylongauthornameverylongauthornamever"));
        }

        [Test]
        public void Catalog_AddBookToCatalog()
        {
            _catalog.AddBookToCatalog(_isbn, _book, _catalog.Books);

            Assert.AreEqual(1, _catalog.Books.Count);
        }

        [Test]
        public void Catalog_AddBookWithAlreadyExistingISBN()
        {
            _catalog.AddBookToCatalog(_isbn, _book, _catalog.Books);

            Assert.Throws<Exception>(() => _catalog.AddBookToCatalog(_isbn, _book, _catalog.Books));
        }

        [Test]
        public void Catalog_AccessNonExistingBookInCatalog()
        {
            Assert.Throws<Exception>(() => _catalog.AccessBookInCatalog("1234567891014", _catalog.Books));
        }

        [Test]
        public void Catalog_GetBooksByAuthorByFirstNameLastNameNoResult()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _catalog.GetSetOfBooksByAuthorFirstNameLastName("Boyan", "Boyanov", _catalog.Books);

                string expected = NotificationMessages.NoBooksByThisAuthor;
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }
    }
}