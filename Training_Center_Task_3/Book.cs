using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Book
    {
        private string isbn;
        private string title;
        private const int titleLength = 1000;
        private DateOnly date;
        private List<Author> authors;

        public string ISBN
        {
            get { return isbn; }
            private set { isbn = value; }
        }

        public string Title
        {
            get { return title; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.TitleCannotBeNull);
                }
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.TitleCannotBeEmpty);
                }
                if (value.Length >= titleLength)
                {
                    throw new Exception(ExceptionMessages.TitleTooLong);
                }
                title = value;
            }
        }
        public List<Author> Authors
        {
            get { return authors; }
            set { authors = value; }
        }

        public DateOnly Date
        {
            get { return date; }
            private set { date = value; }
        }
    }
}
