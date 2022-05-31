using System.Collections;
using Training_Center_Task_3;

//1.Create books, add authors and add books to catalog
string command = String.Empty;
//Catalog bookCatalog = new Catalog();

//while (command != "STOP!")
//{
//    Console.WriteLine("Let's create a new book and add it to catalog. Please enter ISBN");
//    string isbn = Console.ReadLine();
//    Console.WriteLine("Please enter a title");
//    string title = Console.ReadLine();
//    Console.WriteLine("Please enter a date in format year-month-date");
//    DateOnly date = DateOnly.ParseExact(Console.ReadLine(), "yyyy-MM-dd");
//    Console.WriteLine($"Enter first name and last name of book author. If authors are more than one, separate them with a ", "");
//    string authors = Console.ReadLine();
//    string[] allAuthorNames = authors.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
//    List<Author> authorList = new List<Author>();
//    foreach (var item in allAuthorNames)
//    {
//        string[] currentAuthor = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
//        string firstName = currentAuthor[0];
//        string lastName = currentAuthor[1];
//        Author author = new Author(firstName, lastName);
//        authorList.Add(author);
//    }

//    Book book = new Book(isbn, title, date, authorList);

//    bookCatalog.AddBookToCatalog(isbn, book, bookCatalog.Books);

//    command = Console.ReadLine();
//}

//TEST CODE!!!!
string _isbn = "123-4-56-789101-1";
DateOnly date = DateOnly.ParseExact("2022-04-23", "yyyy-MM-dd");

var _authors = new List<Author>();
_authors.Add(new Author("Ivo", "Igov"));

var _book = new Book(_isbn, "Title 2", date, _authors);
Catalog bookCatalog = new Catalog();
bookCatalog.AddBookToCatalog(_isbn, _book, bookCatalog.Books);

//Create second book and add it to catalog
var isbn2 = "1234567891011";
DateOnly date2 = DateOnly.ParseExact("2019-05-19", "yyyy-MM-dd");

var authors2 = new List<Author>();
authors2.Add(new Author("Ivo", "Igov"));
authors2.Add(new Author("Ivan", "Ivanov"));
var _book2 = new Book(isbn2, "Title 1", date2, authors2);
bookCatalog.AddBookToCatalog(isbn2, _book2, bookCatalog.Books);
//Create third book and add it to catalog
var isbn3 = "1234567891012";
DateOnly date3 = DateOnly.ParseExact("2017-08-01", "yyyy-MM-dd");

var authors3 = new List<Author>();
authors3.Add(new Author("Todor", "Todorov"));
var _book3 = new Book(isbn3, "Title 3", date3, authors3);
bookCatalog.AddBookToCatalog(isbn3, _book3, bookCatalog.Books);

//2. Get a set of books for an author's first and last name
Console.WriteLine("Enter first name of author");
string firstNameSearchedAuthor = Console.ReadLine();
Console.WriteLine("Enter last name of author");
string lastNameSearchedAuthor = Console.ReadLine();
var booksByAuthor = bookCatalog.GetSetOfBooksByAuthorFirstNameLastName(firstNameSearchedAuthor, lastNameSearchedAuthor, bookCatalog.Books);
if(booksByAuthor == null)
{
    Console.WriteLine(NotificationMessages.NoBooksByThisAuthor);
}
else
{
    foreach (var item in booksByAuthor)
    {
        Console.WriteLine(item.Title);
    }
};

//3. Get a set of books ordered by publication date in descending order
var orderedBooks = bookCatalog.GetSetOfBooksByPublicationDateDesc(bookCatalog.Books);
if (orderedBooks != null)
{
    foreach (var item in orderedBooks)
    {
        Console.WriteLine(item.Title);
    }
}
else
{
    Console.WriteLine(NotificationMessages.NoBooksInCatalog);
}

//4. Get a set of tuples in the form "author - number of published books"
var listAuthorsNumberOfBooks = bookCatalog.GetSetOfBooksAllAuthorsAndNumberOfBooks(bookCatalog.Books);
if (bookCatalog.Books.Count == 0)
{
    Console.WriteLine(NotificationMessages.NoBooksInCatalog);
}
else
{
    foreach (var item in listAuthorsNumberOfBooks)
    {
        Console.WriteLine($"Author {item.Item1} has {item.Item2} books in catalog!");
    }
}

//5. Get a set of books sorted by title
var sortedCatalogByTitle = bookCatalog.SortBookCatalogByTitle(bookCatalog.Books);
if (bookCatalog.Books.Count == 0)
{
    Console.WriteLine(NotificationMessages.NoBooksInCatalog);
}
else
{
    foreach (var item in sortedCatalogByTitle)
    {
        Console.WriteLine(item.Title);
    }
}

//6. Access book in catalog
Console.WriteLine("To access a book in catalog, write its ISBN");
string searchedISBN = Console.ReadLine();
var accessedBook = bookCatalog.AccessBookInCatalog(searchedISBN, bookCatalog.Books);
if (accessedBook != null)
{
    Console.WriteLine(accessedBook.Title);
}
