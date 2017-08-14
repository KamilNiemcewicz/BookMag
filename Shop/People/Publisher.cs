using System;
using System.Collections.Generic;
using Shop.Book;
using Shop.Core;

namespace Shop.People
{
    public class Publisher : Person
    {
        public IList<BookBase> PublishedBooks = new List<BookBase> { };

        public Publisher(int personId, string name, string surname, string birthDate, string birthPlace, string deathDate, string deathPlace, string sex, string website, IList<BookBase> books) 
            : base(personId, name, surname, birthDate, birthPlace, deathDate, deathPlace, sex, website)
        {
            PublishedBooks = books;
        }

        public override void AddBook(BookBase book)
        {
            throw new NotImplementedException();
        }
    }
}