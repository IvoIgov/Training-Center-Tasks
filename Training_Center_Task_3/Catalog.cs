﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Catalog : IEnumerable
    {
        private List<Book> _books = new List<Book>();


        public List<Book> Books
        {
            get { return this._books; }
            set { _books = value; }
        }

        /// <summary>
        /// This method adds a new book to catalog and returns the updated catalog. 
        /// if a book with the given ISBN already exists, it throws an error
        /// </summary>
        public List<Book> AddBookToCatalog(string isbn, Book book, List<Book> bookCatalog)
        {
            var isISBNPresent = bookCatalog.Where(x => x.ISBN == isbn).Any();
            if (isISBNPresent == false)
            {
                bookCatalog.Add(book);
            }
            else
            {
                throw new Exception(ExceptionMessages.CatalogAlreadyContainsBookWithThisISBN);
            }
            return bookCatalog;
        }

        /// <summary>
        /// This method accesses a book in the catalog by ISBN and returns its name or an error message.
        /// </summary>
        public void AccessBookInCatalog(string isbn, List<Book> bookCatalog)
        {
            var bookExists = bookCatalog.Exists(x => x.ISBN == isbn);
            if (bookExists)
            {
                var book = bookCatalog.Where((x) => x.ISBN == isbn).FirstOrDefault();
                Console.WriteLine(book.Title);
            }
            else
            {
                Console.WriteLine(ExceptionMessages.BookWithThisISBNDoesNotExist);
            }
        }

        /// <summary>
        /// This method returns all books by a given author
        /// </summary>
        public void GetSetOfBooksByAuthorFirstNameLastName(string firstName, string lastName, List<Book> bookCatalog)
        {
            string fullName = firstName.ToLower() + " " + lastName.ToLower();
            var book = from a in bookCatalog from b in a.Authors where (b.FullName == fullName) select a;
            foreach (var item in book)
            {
                Console.WriteLine(item.Title);
            }
        }

        /// <summary>
        /// this method sorts and prints a list of all books ordered by date descending
        /// </summary>
        public void GetSetOfBooksByPublicationDateDesc(List<Book> bookCatalog)
        {
            var list = from b in bookCatalog orderby b.Date descending select b;

            foreach (var item in list)
            {
                Console.WriteLine(item.Title);
            }
        }

        /// <summary>
        /// This method sorts the book catalog and prints a key-value pair of Author -> number of author's books
        /// </summary>
        public string GetSetOfBooksByAuthorNumberOfBooks(List<Book> bookCatalog)
        {
            return null;
        }

        /// <summary>
        /// This method sorts the book catalog by book title and returns it
        /// </summary>
        public void SortBookCatalogByTitle(List<Book> bookCatalog)
        {
            var list = from b in bookCatalog orderby b.Title select b;
            foreach (var item in list)
            {
                Console.WriteLine(item.Title);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
