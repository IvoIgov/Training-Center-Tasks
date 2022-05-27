using NUnit.Framework;
using System;
using System.Collections.Generic;
using Training_Center_Task_3;

namespace Training_Center_Task_3_Unit_Tests
{
    public class Tests
    {
        private List<Author> _authors;
        [SetUp]
        public void Setup()
        {
            List<Author> _authors = new List<Author>();
            _authors.Add(new Author("Ivo", "Igov"));
        }

        [Test]
        public void Ctor_CreateBookValidData()
        {
            string isbn = "123-4-56-789101-1";
            string title = "Title 2";
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            Book book = new Book(isbn, title, date, _authors);
            Assert.AreEqual(book.ISBN, "123-4-56-789101-1");
            Assert.AreEqual(book.Title, "Title 2");
            Assert.AreEqual(book.Date, date);
            Assert.AreEqual(book.Authors.Count, 1);
        }

        [Test]
        public void Ctor_CreateBookInvalidISBN()
        {
            string isbn = "123-4-56-789101";
            string title = "Title 2";
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            Assert.Throws<Exception>(() => new Book(isbn, title, date, _authors));
        }

        [Test]
        public void Ctor_CreateBookInvalidTitleEmpty()
        {
            string isbn = "123-4-56-789101-1";
            string title = "";
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            Assert.Throws<ArgumentException>(() => new Book(isbn, title, date, _authors));
        }

        [Test]
        public void Ctor_CreateBookInvalidDateFormat()
        {
            string isbn = "123-4-56-789101-1";
            string title = "Title 2";

            Assert.Throws<FormatException>(() => DateOnly.ParseExact("2022-13-23", "yyyy-MM-dd"));
        }


    }
}