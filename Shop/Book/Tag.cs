using System.Collections.Generic;

namespace Shop.Book
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public IList<BookBase> Books { get; set; }
    }
}