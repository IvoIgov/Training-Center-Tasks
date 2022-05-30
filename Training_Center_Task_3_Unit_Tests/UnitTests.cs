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
        public void Catalog_AccessAlreadyExistingBookInCatalog()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                AddThreeBooksToCatalog(_catalog);
                _catalog.AccessBookInCatalog(_isbn, _catalog.Books);
                string expected = "Title 2";
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }

        [Test]
        public void Catalog_AddBookWithAlreadyExistingISBN()
        {
            Assert.Throws<Exception>(() => _catalog.AccessBookInCatalog("1234567891014", _catalog.Books));
        }

        [Test]
        public void Catalog_AccessExistingBookInCatalog()
        {
            AddThreeBooksToCatalog(_catalog);
            _catalog.AccessBookInCatalog(_isbn, _catalog.Books);
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

        [Test]
        public void Catalog_GetBooksByAuthorByFirstNameLastNameWithResult()
        {
            using (StringWriter sw = new StringWriter())
            {
                _catalog.AddBookToCatalog(_isbn, _book, _catalog.Books);
                Console.SetOut(sw);

                _catalog.GetSetOfBooksByAuthorFirstNameLastName("Ivo", "Igov", _catalog.Books);

                string expected = "Title 2";
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }

        [Test]
        public void Catalog_GetSetOfBooksByPublicationDatesDescNoResult()
        {
            using (StringWriter sw = new StringWriter())
            {
                var catalog = new Catalog();

                Console.SetOut(sw);

                _catalog.GetSetOfBooksByPublicationDateDesc(_catalog.Books);

                string expected = NotificationMessages.NoBooksInCatalog;
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }

        [Test]
        public void Catalog_GetSetOfBooksByPublicationDatesDescWithResult()
        {
            using (StringWriter sw = new StringWriter())
            {
                AddThreeBooksToCatalog(_catalog);
                Console.SetOut(sw);

                _catalog.GetSetOfBooksByPublicationDateDesc(_catalog.Books);

                string expected = "Title 2\r\nTitle 1\r\nTitle 3";
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }

        [Test]
        public void Catalog_GetSetOfBooksByAuthor()
        {
            using (StringWriter sw = new StringWriter())
            {
                AddThreeBooksToCatalog(_catalog);
                Console.SetOut(sw);

                _catalog.GetSetOfBooksByAuthorNumberOfBooks(_catalog.Books);

                string expected = "Author ivo igov has 2 books in catalog!\r\nAuthor ivan ivanov has 1 books in catalog!\r\nAuthor todor todorov has 1 books in catalog!";
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }

        [Test]
        public void Catalog_SortBookCatalogEmpty()
        {
            using (StringWriter sw = new StringWriter())
            {
                var catalog = new Catalog();
                Console.SetOut(sw);

                catalog.SortBookCatalogByTitle(catalog.Books);

                string expected = NotificationMessages.NoBooksInCatalog;
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }

        [Test]
        public void Catalog_SortBookCatalogHasBooks()
        {
            using (StringWriter sw = new StringWriter())
            {
                AddThreeBooksToCatalog(_catalog);
                Console.SetOut(sw);

                _catalog.SortBookCatalogByTitle(_catalog.Books);

                string expected = "Title 1\r\nTitle 2\r\nTitle 3";
                Assert.AreEqual(expected.ToString(), sw.ToString().TrimEnd());
            }
        }

        public void AddThreeBooksToCatalog(Catalog catalog)
        {
            _catalog.AddBookToCatalog(_isbn, _book, _catalog.Books);

            //Create second book and add it to catalog
            var isbn2 = "1234567891011";
            DateOnly date2 = DateOnly.ParseExact("2019-05-19", "yyyy-MM-dd");

            var authors2 = new List<Author>();
            authors2.Add(new Author("Ivo", "Igov"));
            authors2.Add(new Author("Ivan", "Ivanov"));
            var _book2 = new Book(isbn2, "Title 1", date2, authors2);
            _catalog.AddBookToCatalog(isbn2, _book2, _catalog.Books);
            //Create third book and add it to catalog
            var isbn3 = "1234567891012";
            DateOnly date3 = DateOnly.ParseExact("2017-08-01", "yyyy-MM-dd");

            var authors3 = new List<Author>();
            authors3.Add(new Author("Todor", "Todorov"));
            var _book3 = new Book(isbn3, "Title 3", date3, authors3);
            _catalog.AddBookToCatalog(isbn3, _book3, _catalog.Books);
        }
    }
}