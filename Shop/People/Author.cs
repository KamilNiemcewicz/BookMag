using System.Collections.Generic;
using Shop.Book;
using Shop.Core;

namespace Shop.People
{
    public sealed class Author : Person
    {
        public IList<BookBase> WrittenBooks = new List<BookBase> { };


        public Author(int personId, string name, string surname, string birthDate, string birthPlace, string deathDate, string deathPlace, string sex, string website, IList<BookBase> books ) 
            : base(personId, name, surname, birthDate, birthPlace, deathDate, deathPlace, sex, website)
        {
            WrittenBooks = books;
        }

        public override void AddBook(BookBase book)
        {
            WrittenBooks.Add(book);
        }
    }
}