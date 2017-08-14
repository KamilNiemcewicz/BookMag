using System.Collections.Generic;
using Shop.Book;
using Shop.Core;

namespace Shop.People
{
    public class Translator : Person
    {
        public IList<BookBase> TranslatedBook = new List<BookBase> { };

        public Translator(int personId, string name, string surname, string birthDate, string birthPlace, string deathDate, string deathPlace, string sex, string website, IList<BookBase> books) 
            : base(personId, name, surname, birthDate, birthPlace, deathDate, deathPlace, sex, website)
        {
            TranslatedBook = books;
        }

        public override void AddBook(BookBase book)
        {
            TranslatedBook.Add(book);
        }

    }
}