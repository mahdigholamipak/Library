using Library.Models;
using System.Linq.Expressions;

namespace Library.Repositories
{
    internal interface IBookRepository: IRepository<Book>
    {
        Book GetBook(int id);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> FindBooks(Expression<Func<Book, bool>> predicate);
        void AddBook(Book book);
        void RemoveBook(Book book);
        void UpdateBook(Book book);
    }
}
