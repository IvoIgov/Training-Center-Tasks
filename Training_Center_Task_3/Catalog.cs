using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_3
{
    public class Catalog
    {
        private string _isbn;
        private Dictionary<string, List<Author>> _catalog;

        public string ISBN { get; set; }
        public Dictionary<string, List<Author>> Authors { get; set; }

        public Catalog(string isbn, List<Author> authors)
        {
            this.ISBN = isbn;
            this.Authors = new Dictionary<string, List<Author>>();
        }
    }
}
