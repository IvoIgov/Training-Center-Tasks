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
        private Dictionary<string, Book> _books = new Dictionary<string, Book>();


        public Catalog()
        {
            this.Books = new Dictionary<string, Book>();
        }

        public Dictionary<string, Book> Books
        {
            get { return this._books; }
            set { _books = value; }
        }

        /// <summary>
        /// This method adds a new book to catalog and returns the updated catalog. 
        /// if a book with the given ISBN already exists, it throws an error
        /// </summary>
        public Dictionary<string, Book> AddBookToCatalog(string isbn, Book book, Dictionary<string, Book> bookCatalog)
        {
            if (bookCatalog.ContainsKey(isbn))
            {
                throw new Exception(ExceptionMessages.CatalogAlreadyContainsBookWithThisISBN);
            }
            else
            {
                bookCatalog.Add(isbn, book);
            }
            return bookCatalog;
        }

        /// <summary>
        /// This method accesses a book in the catalog and returns a Book object.
        /// </summary>
        public Book AccessBookInCatalog(string isbn, Dictionary<string, Book> bookCatalog)
        {
            if (bookCatalog.ContainsKey(isbn))
            {
                return bookCatalog[isbn];
            }

            return null;
        }

        /// <summary>
        /// This method sorts the book catalog by book title and returns it
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Book> SortBookCatalogSortedByTitle(Dictionary<string, Book> bookCatalog)
        {
            bookCatalog = bookCatalog.OrderBy(x => x.Value.Title).ToDictionary(x => x.Key, y => y.Value);

            return bookCatalog;
        }

        //public Dictionary<string, Book> GetSetOfBooksByAuthorFirstNameLastName(string firstName, string lastName, Dictionary<string, Book> bookCatalog)
        //{
        //    string fullName = firstName + " " + lastName;
        //    bool exists = false;
        //    var list = from b in bookCatalog where b.Value. select b;

        //    return list;
        //} 

        public void GetSetOfBooksByPublicationDateDesc(Dictionary<string, Book> bookCatalog)
        {
            var list = from b in bookCatalog orderby b.Value.Date descending select b;
            foreach (var item in list)
            {
                Console.WriteLine(item.Value.Title);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
