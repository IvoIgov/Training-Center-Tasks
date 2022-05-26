

using System.Collections;
using Training_Center_Task_3;

//Create books, add authors and add books to catalog
string command = Console.ReadLine();
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
}

//2. Get a set of books sorted by title
bookCatalog.SortBookCatalogByTitle(bookCatalog.Books);

//3. Get a set of books for an author's first and last name
Console.WriteLine("Enter first and last name of author");
string firstNameSearchedAuthor = Console.ReadLine();
string lastNameSearchedAuthor = Console.ReadLine();
bookCatalog.GetSetOfBooksByAuthorFirstNameLastName(firstNameSearchedAuthor, lastNameSearchedAuthor, bookCatalog.Books);

//4. Get a set of books ordered by publication date in descending order
bookCatalog.GetSetOfBooksByPublicationDateDesc(bookCatalog.Books);

//5. Get a set of tuples in the form "author - number of published books"
bookCatalog.GetSetOfBooksByAuthorNumberOfBooks(bookCatalog.Books);

//foreach (var item in func(2, 10))
//{
//    Console.WriteLine(item);
//}
//Console.Read();

//static IEnumerable func(int start, int number)
//{
//    for (int i = 0; i < number; i++)
//    {
//        yield return start + 2 * i;
//    }
//}

