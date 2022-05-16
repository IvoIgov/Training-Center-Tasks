using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Website
{
    public static class ExceptionMessages
    {
        public const string InvalidTextDescriptionLength = "Text must be up to 256 characters long!";
        public const string EmptyText = "Text must not be empty!";
        public const string EmptyVideoURI = "Video content URI must not be empty!";
        public const string TextLength = "Maximum text is 10000 characters!";
        public const string EmptyContentURI = "Content URI must not be empty!";

    }
}
