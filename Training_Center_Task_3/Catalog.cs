using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Catalog
    {
        private Dictionary<string, Book> _catalog;


        public Catalog(string isbn, List<Book> authors)
        {
            this.Authors = new Dictionary<string, Book>();
        }

        public Dictionary<string, Book> Authors { get; set; }

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

        public bool AccessBookInCatalog(string isbn)
        {
            return true;
        }
    }
}
