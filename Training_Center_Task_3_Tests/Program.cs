using System.Collections;
using Training_Center_Task_3;

//1.Create books, add authors and add books to catalog
string command = String.Empty;
Catalog bookCatalog = new Catalog();

while (command != "STOP!")
{
    Console.WriteLine("Let's create a new book and add it to catalog. Please enter ISBN");
    string isbn = Console.ReadLine();
    Console.WriteLine("Please enter a title");
    string title = Console.ReadLine();
    Console.WriteLine("Please enter a date in format year-month-date");
    DateOnly date = DateOnly.ParseExact(Console.ReadLine(), "yyyy-MM-dd");
    Console.WriteLine($"Enter first name and last name of book author. If authors are more than one, separate them with a ", "");
    string authors = Console.ReadLine();
    string[] allAuthorNames = authors.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
    List<Author> authorList = new List<Author>();
    foreach (var item in allAuthorNames)
    {
        string[] currentAuthor = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
        string firstName = currentAuthor[0];
        string lastName = currentAuthor[1];
        Author author = new Author(firstName, lastName);
        authorList.Add(author);
    }

    Book book = new Book(isbn, title, date, authorList);

    bookCatalog.AddBookToCatalog(isbn, book, bookCatalog.Books);

    command = Console.ReadLine();
}

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
