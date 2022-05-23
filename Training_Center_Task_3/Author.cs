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
        private const int _firstNameLength = 200;
        private string _lastName;
        private const int _lastNameLength = 200;
        

        public string FirstName
        {
            get { return _firstName; }
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
                if (value.Length >= _lastNameLength)
                {
                    throw new Exception(ExceptionMessages.AuthorLastNameTooLong);
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
                    throw new ArgumentNullException(ExceptionMessages.AuthorFirstNameCannotBeNull);
                }
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.AuthorFirstNameCannotBeEmpty);
                }
                if (value.Length >= _firstNameLength)
                {
                    throw new Exception(ExceptionMessages.AuthorFirstNameTooLong);
                }
                _firstName = value;
            }
        }

    }
}
