using NUnit.Framework;
using System;
using System.Collections.Generic;
using Training_Center_Task_3;

namespace Training_Center_Task_3_Unit_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_CreateBookValidData()
        {
            List<Author> authors = new List<Author>();
            authors.Add(new Author("Ivo", "Igov"));
            string isbn = "123-4-56-789101-1";
            string title = "Title 2";
            DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

            Book book = new Book(isbn, title, date, authors);
            Assert.AreEqual(book.ISBN, "123-4-56-789101-1");
            Assert.AreEqual(book.Title, "Title 2");
            Assert.AreEqual(book.Date, date);
            Assert.AreEqual(book.Authors.Count, 1);
        }
    }
}