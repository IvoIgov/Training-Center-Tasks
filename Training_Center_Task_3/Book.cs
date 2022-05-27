using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Book
    {
        private string _isbn;
        private string _title;
        private const int TITLE_LENGTH = 1000;
        private DateOnly _date = default;
        private List<Author> _authors = new List<Author>();
        private const string REGEX_ISBN = @"[0-9]{3}([\-]?)[0-9]{1}\1[0-9]{2}\1[0-9]{6}\1[0-9]{1}";

        public Book(string isbn, string title, DateOnly? date, List<Author> authors)
        {
            this.ISBN = isbn;
            this.Title = title;
            if (date != null)
            {
                this.Date = (DateOnly)date;
            }
            this.Authors = authors;
        }
        public string ISBN
        {
            get { return _isbn; }
            private set 
            {
                Match match = Regex.Match(value, REGEX_ISBN, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    _isbn = value;
                }
                else
                {
                    throw new Exception(ExceptionMessages.BookISBNInvalid);
                } 
            }
        }

        public string Title
        {
            get { return _title; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.BookTitleCannotBeNull);
                }
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.BookTitleCannotBeEmpty);
                }
                if (value.Length >= TITLE_LENGTH)
                {
                    throw new Exception(ExceptionMessages.BookTitleTooLong);
                }
                _title = value;
            }
        }
        public List<Author> Authors
        {
            get { return _authors; }
            private set { _authors = value; }
        }

        public DateOnly Date
        {
            get { return _date; }
            private set {
                DateOnly result;
                var success = DateOnly.TryParse(value.ToString(), out result);
                if (success == false)
                {
                    throw new Exception(ExceptionMessages.BookDateInvalidFormat);
                }
                _date = value; }
        }
    }
}
