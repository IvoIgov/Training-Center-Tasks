using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Catalog
    {
        private Dictionary<string, List<Book>> _catalog;


        public Catalog(string isbn, List<Book> authors)
        {
            this.Authors = new Dictionary<string, List<Book>>();
        }

        public Dictionary<string, List<Book>> Authors { get; set; }

        public List<Book> AddBookToCatalog(string isbn, Book book, List<Book> bookCatalog)
        {

            return bookCatalog;
        }

        public bool AccessBookInCatalog(string isbn)
        {
            return true;
        }
    }
}
