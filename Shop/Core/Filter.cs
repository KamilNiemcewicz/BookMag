using Shop.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Book.Enums;

namespace Shop.Core
{
    public interface ISpecification<T> 
    {
        bool IsSatisfied(T book);
    }
    public interface IFilter<T> 
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class SizeSpecification : ISpecification<PapperBook>
    {
        private readonly BookSize _bookSize;

        public SizeSpecification(BookSize bookSize)
        {
            this._bookSize = bookSize;
        }

        public bool IsSatisfied(PapperBook book)
        {
            return book.Size == _bookSize;
        }
    }
    public class ConditionSpecification : ISpecification<PapperBook>
    {
        private readonly BookCondition _bookCondition;

        public ConditionSpecification(BookCondition condition)
        {
            this._bookCondition = condition;
        }

        public bool IsSatisfied(PapperBook book)
        {
            return book.Condition == _bookCondition;
        }
    }
    public class BookBindingSpecification : ISpecification<PapperBook>
    {
        private readonly BookBindingType _bindingType;

        public BookBindingSpecification(BookBindingType size)
        {
            this._bindingType = size;
        }

        public bool IsSatisfied(PapperBook book)
        {
            return book.BindingType == _bindingType;
        }
    }
    public class SubjectSpecification : ISpecification<BookBase>
    {
        private readonly BookSubject _bookSubject;

        public SubjectSpecification(BookSubject bookSubject)
        {
            this._bookSubject = bookSubject;
        }

        public bool IsSatisfied(BookBase book)
        {
            return book.Subject == _bookSubject;
        }
    }
    public class LanguageSpecification : ISpecification<BookBase>
    {
        private readonly BookLanguage _bookLanguage;

        public LanguageSpecification(BookLanguage size)
        {
            this._bookLanguage = size;
        }

        public bool IsSatisfied(BookBase book)
        {
            return book.Language == _bookLanguage;
        }
    }
    public class EBookFormatSpecification : ISpecification<EBook>
    {
        private readonly EBookFormat _eBookFormat;

        public EBookFormatSpecification(EBookFormat eBookFormat)
        {
            this._eBookFormat = eBookFormat;
        }

        public bool IsSatisfied(EBook book)
        {
            return book.EbookFormat == _eBookFormat;
        }
    }
    public class ManyPapperBookpecification : ISpecification<PapperBook>
    {
        private readonly ISpecification<PapperBook>[] _specifications;

        public ManyPapperBookpecification(params ISpecification<PapperBook>[] first) 
        {
            this._specifications = first ?? throw new ArgumentNullException(paramName: nameof(first));
        }

        public bool IsSatisfied(PapperBook book)
        {
            return _specifications.All(specification => specification.IsSatisfied(book) != false);
        }
    }
    public class ManyEBookpecification : ISpecification<EBook>
    {
        private readonly ISpecification<EBook>[] _specifications;

        public ManyEBookpecification(params ISpecification<EBook>[] first)
        {
            this._specifications = first ?? throw new ArgumentNullException(paramName: nameof(first));
        }

        public bool IsSatisfied(EBook book)
        {
            return _specifications.All(specification => specification.IsSatisfied(book) != false);
        }
    }

    public class BookFilter<T> : IFilter<T> where T : BookBase
    {
        public IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec)
        {
            return items.Where(spec.IsSatisfied);
        }
    }

}
