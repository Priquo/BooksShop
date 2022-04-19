using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksShop
{
    public partial class books
    {
        public string descriptionLess { get => Description.Substring(0, 100)+ "..."; }
    }
}
