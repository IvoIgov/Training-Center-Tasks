using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Author
    {
        private string _firstName;
        private const int FIRST_NAME_LENGTH = 200;
        private string _lastName;
        private const int LAST_NAME_LENGTH = 200;

        public Author(string firstName, string lastName)
        {
            this.FirstName = firstName.ToLower();
            this.LastName = lastName.ToLower();
            this.FullName = FirstName + " " + LastName;
        }
        public string FirstName
        {
            get { return _firstName; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.AuthorFirstNameCannotBeNull);
                }
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.AuthorFirstNameCannotBeEmpty);
                }
                if (value.Length >= FIRST_NAME_LENGTH)
                {
                    throw new Exception(ExceptionMessages.AuthorFirstNameTooLong);
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.AuthorLastNameCannotBeNull);
                }
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.AuthorLastNameCannotBeEmpty);
                }
                if (value.Length >= FIRST_NAME_LENGTH)
                {
                    throw new Exception(ExceptionMessages.AuthorLastNameTooLong);
                }
                _lastName = value;
            }
        }

        public string FullName { get; set; }

    }
}
