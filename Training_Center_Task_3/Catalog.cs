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
        private Dictionary<string, Book> _catalog;


        public Catalog(string isbn, List<Book> authors)
        {
            this.Authors = new Dictionary<string, Book>();
        }

        public Dictionary<string, Book> Authors { get; set; }

        /// <summary>
        /// This method adds a new book to catalog and returns the updated catalog. 
        /// if a book with the given ISBN already exists, it throws an error
        /// </summary>
        public Dictionary<string, Book> AddBookToCatalog(string isbn, Book book, Dictionary<string, Book> bookCatalog)
        {
            if(bookCatalog.ContainsKey(isbn))
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

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
