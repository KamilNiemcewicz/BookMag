using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Book.Enums;
using Shop.People;

namespace Shop.Book
{
    public abstract class BookBase 
    {
        public int BookId { get; set; }
        public Guid Guid { get; set; }
        public string Title { get;  set; }
        public string OriginalTitle { get;  set; }
        public string Isbn { get; private set; }
        public int NumberOfPages { get;  set; }
        public virtual IList<Author> Authors { get;  set; }
        public virtual IList<Publisher> Publishers { get;  set; }
        public virtual IList<Translator> Translators { get;  set; }
        public virtual IList<Tag> Tags { get; set; }
        public DateTime? DatePublished { get;  set; }
        public BookSubject Subject { get;  set; }
        public BookLanguage Language { get;  set; }
        public bool Active { get; set; }
        public bool test { get; set; }
        protected BookBase(int bookId, Guid guid, string title, string originalTitle, string isbn, int numberOfPages, IList<Author> authors, IList<Publisher> publishers, IList<Translator> translators, IList<Tag> tags, DateTime? datePublished, BookSubject subject, BookLanguage language, bool active)
        {
            BookId = bookId ?? throw new ArgumentNullException(bookId);
            Guid = guid;
            Title = title;
            OriginalTitle = originalTitle;
            Isbn = isbn;
            NumberOfPages = numberOfPages;
            Authors = authors;
            Publishers = publishers;
            Translators = translators;
            Tags = tags;
            DatePublished = datePublished;
            Subject = subject;
            Language = language;
            Active = active;
        }

        protected BookBase()
        {
        }

        public string SetIsbn(string isbn)
        {
            if (IsbnValidator.TryValidate(isbn))
                return isbn;

            throw new Exception("Błędny numer ISBN.");
        }

        public override string ToString()
        {
            return $"Tytuł: {Title}";
        }

    }
}
