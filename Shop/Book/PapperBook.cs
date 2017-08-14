using System;
using System.Collections.Generic;
using Shop.Book.Enums;
using Shop.People;

namespace Shop.Book
{
    public class PapperBookBuilder
    {
        protected PapperBook PapperBook = new PapperBook();
        public PapperBookBasicInfoBuilder Add => new PapperBookBasicInfoBuilder(PapperBook);
    }

    public class PapperBookBasicInfoBuilder : PapperBookBuilder
    {
        public PapperBookBasicInfoBuilder(PapperBook papperBook)
        {
            this.PapperBook = papperBook;
        }

        public PapperBookBasicInfoBuilder BasicInfo(int id, Guid guid, string title, string originalTitle, string isbn, int numberOfPages,
            DateTime datePublished)
        {
            PapperBook.BookId = id;
            PapperBook.Guid = guid;
            PapperBook.Title = title;
            PapperBook.OriginalTitle = string.IsNullOrWhiteSpace(originalTitle) ? "" : originalTitle;
            PapperBook.SetIsbn(isbn);
            PapperBook.NumberOfPages = numberOfPages;
            PapperBook.DatePublished = datePublished;

            return this;
        }

        public PapperBookBasicInfoBuilder PeopleInfo(List<Author> authors, List<Publisher> publishers, List<Translator> translators)
        {

            PapperBook.Authors = authors;
            PapperBook.Publishers = publishers;
            PapperBook.Translators = translators;
            return this;
        }

        public PapperBookBasicInfoBuilder AdditionalInfo(BookSubject subject, BookLanguage language, BookSize size, BookCondition condition,
            BookBindingType bindingType)
        {
            PapperBook.Subject = subject;
            PapperBook.Language = language;
            PapperBook.Size = size;
            PapperBook.Condition = condition;
            PapperBook.BindingType = bindingType;
            return this;
        }

        public PapperBookBasicInfoBuilder AddTag(Tag tag)
        {
            PapperBook.Tags.Add(tag);
            return this;
        }

        public PapperBook build()
        {
            return PapperBook;
        }
    }

    public sealed class PapperBook : BookBase
    {
        public BookSize Size { get; set; }
        public BookCondition Condition { get; set; }
        public BookBindingType BindingType { get; set; }

        public PapperBook(int bookId, Guid guid, string title, string originalTitle, string isbn, int numberOfPages, IList<Author> authors, IList<Publisher> publishers, IList<Translator> translators, IList<Tag> tags, DateTime? datePublished, BookSubject subject, BookLanguage language, BookSize size, BookCondition condition, BookBindingType bindingType, bool active) 
            : base(bookId, guid, title, originalTitle, isbn, numberOfPages, authors, publishers, translators, tags, datePublished, subject, language, active)
        {
            Size = size;
            Condition = condition;
            BindingType = bindingType;
        }

        public PapperBook()
        {
        }
    }
}