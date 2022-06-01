using System.Collections;

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

        public Catalog()
        {
            this.Books = _books;
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
        public Book AccessBookInCatalog(string isbn, List<Book> bookCatalog)
        {
            var bookExists = bookCatalog.Exists(x => x.ISBN == isbn);
            if (bookExists)
            {
                return bookCatalog.Where((x) => x.ISBN == isbn).FirstOrDefault();
            }
            else
            {
                throw new Exception(ExceptionMessages.BookWithThisISBNDoesNotExist);
            }
        }

        /// <summary>
        /// This method returns all books by a given author
        /// </summary>
        public List<Book> GetSetOfBooksByAuthorFirstNameLastName(string firstName, string lastName, List<Book> bookCatalog)
        {
            string fullName = firstName.ToLower() + " " + lastName.ToLower();
            var book = from a in bookCatalog from b in a.Authors where (b.FullName == fullName) select a;
            return book.ToList();
        }


        /// <summary>
        /// this method sorts and prints a list of all books ordered by date descending
        /// </summary>
        public List<Book> GetSetOfBooksByPublicationDateDesc(List<Book> bookCatalog)
        {
            var list = from b in bookCatalog orderby b.Date descending select b;
            if (bookCatalog.Count == 0)
            {
                return bookCatalog;
            }
            else
            {
                return list.ToList<Book>();
            }
        }

        /// <summary>
        /// This method sorts the book catalog and prints a key-value pair of Author -> number of author's books
        /// </summary>
        public List<Tuple<string, int>> GetSetOfBooksAllAuthorsAndNumberOfBooks(List<Book> bookCatalog)
        {
            var list = new List<Tuple<string, int>>();
            var result = from b in bookCatalog from a in b.Authors group b by a.FullName;
            if (bookCatalog.Count == 0)
            {
                throw new Exception(NotificationMessages.NoBooksInCatalog);
            }
            else
            {
                foreach (var item in result)
                {
                    list.Add(new Tuple<string, int>(item.Key, item.ToList().Count));
                }
                return list;
            }
        }

        /// <summary>
        /// This method sorts the book catalog by book title and returns it
        /// </summary>
        public List<Book> SortBookCatalogByTitle(List<Book> bookCatalog)
        {
            var list = from b in bookCatalog orderby b.Title select b;
            if (bookCatalog.Count == 0)
            {
                return bookCatalog;
            }
            else
            {
                return list.ToList<Book>();
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
