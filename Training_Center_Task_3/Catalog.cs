using System;
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
        /// This method accesses a book in the catalog and returns a Book object.
        /// </summary>
        public Book AccessBookInCatalog(string isbn, List<Book> bookCatalog)
        {
            //var book = bookCatalog.Where((x) => x.ISBN == isbn).FirstOrDefault();
            var book = from b in bookCatalog where b.ISBN == isbn select b;
            if (book == null)
            {
                throw new Exception (ExceptionMessages.BookWithThisISBNDoesNotExist);
            }
            return (Book)book;
        }

        /// <summary>
        /// This method sorts the book catalog by book title and returns it
        /// </summary>
        public List<Book> SortBookCatalogByTitle(List<Book> bookCatalog)
        {
            bookCatalog = bookCatalog.OrderBy(x => x.Title).ToList();

            return bookCatalog;
        }

        /// <summary>
        /// This method returns all books by a given author
        /// </summary>

        public List<Book> GetSetOfBooksByAuthorFirstNameLastName(string firstName, string lastName, List<Book> bookCatalog)
        {
            string fullName = firstName.ToLower() + " " + lastName.ToLower();
            var list = new List<Book>();
            var book = from a in bookCatalog from b in a.Authors where (b.FullName == fullName) select a;
            return list;
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

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
