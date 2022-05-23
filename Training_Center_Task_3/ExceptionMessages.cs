using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class ExceptionMessages
    {
        public const string BookISBNInvalid = "ISBN is not valid!"
        public const string BookTitleCannotBeEmpty = "Title cannot be empty!";
        public const string BookTitleCannotBeNull = "Title cannot be null!";
        public const string BookTitleTooLong = "Title cannot be more than 1000 characters long!";
        public const string AuthorFirstNameCannotBeEmpty = "Author first name cannot be empty!";
        public const string AuthorFirstNameCannotBeNull = "Author first name cannot be null!";
        public const string AuthorFirstNameTooLong = "Author first name cannot be more than 200 characters!";
        public const string AuthorLastNameCannotBeEmpty = "Author last name cannot be empty!";
        public const string AuthorLastNameCannotBeNull = "Author last name cannot be null!";
        public const string AuthorLastNameTooLong = "Author larst name cannot be more than 200 characters!";
        public const string CatalogAlreadyContainsBookWithThisISBN = "Book with this ISBN aready exists in catalog!";
    }
}
