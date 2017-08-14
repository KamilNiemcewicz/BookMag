using System;
using System.Collections.Generic;
using Shop.Book.Enums;
using Shop.People;

namespace Shop.Book
{
    public class EBookBuilder
    {
        protected EBook EBook = new EBook();
        public EBookBasicInfoBuilder Add => new EBookBasicInfoBuilder(EBook);
    }

    public class EBookBasicInfoBuilder : EBookBuilder
    {
        public EBookBasicInfoBuilder(EBook eBook)
        {
            this.EBook = eBook;
        }

        public EBookBasicInfoBuilder BasicInfo(int id, Guid guid, string title, string originalTitle, string isbn, int numberOfPages,
            DateTime datePublished)
        {
            EBook.BookId = id;
            EBook.Guid = guid;
            EBook.Title = title;
            EBook.OriginalTitle = string.IsNullOrWhiteSpace(originalTitle) ? "" : originalTitle;
            EBook.SetIsbn(isbn);
            EBook.NumberOfPages = numberOfPages;
            EBook.DatePublished = datePublished;

            return this;
        }

        public EBookBasicInfoBuilder PeopleInfo(List<Author> authors, List<Publisher> publishers, List<Translator> translators)
        {

            EBook.Authors = authors;
            EBook.Publishers = publishers;
            EBook.Translators = translators;
            return this;
        }

        public EBookBasicInfoBuilder AdditionalInfo(BookSubject subject, BookLanguage language, EBookFormat ebookFormat)
        {
            EBook.Subject = subject;
            EBook.Language = language;
            EBook.EbookFormat = ebookFormat;
            return this;
        }

        public EBookBasicInfoBuilder AddTag(Tag tag)
        {
            EBook.Tags.Add(tag);
            return this;
        }

        public EBook Build()
        {
            return EBook;
        }
    }
    public class EBook : BookBase
    {
        public EBookFormat EbookFormat { get; set; }

        public EBook(int bookId, Guid guid, string title, string originalTitle, string isbn, int numberOfPages, IList<Author> authors, IList<Publisher> publishers, IList<Translator> translators, IList<Tag> tags, DateTime? datePublished, BookSubject subject, BookLanguage language, EBookFormat ebookFormat, bool active) 
            : base(bookId, guid, title, originalTitle, isbn, numberOfPages, authors, publishers, translators, tags, datePublished, subject, language, active)
        {
            EbookFormat = ebookFormat;
        }
        

        public EBook()
        {
        }
    }
}