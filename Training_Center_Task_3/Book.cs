using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Book
    {
        private string _isbn;
        private string _title;
        private const int _titleLength = 1000;
        private DateOnly _date;
        private List<Author> _authors;

        public string ISBN
        {
            get { return _isbn; }
            private set { _isbn = value; }
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
                if (value.Length >= _titleLength)
                {
                    throw new Exception(ExceptionMessages.BookTitleTooLong);
                }
                _title = value;
            }
        }
        public List<Author> Authors
        {
            get { return _authors; }
            set { _authors = value; }
        }

        public DateOnly Date
        {
            get { return _date; }
            private set { _date = value; }
        }
    }
}
