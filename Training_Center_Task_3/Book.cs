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

        public string Title
        {
            get { return title; }
            private set 
            { 
                if (String.IsNullOrEmpty(value))
                {

                }
                title = value; }
        }


        public string ISBN
        {
            get { return isbn; }
            private set { isbn = value; }
        }

    }
}
