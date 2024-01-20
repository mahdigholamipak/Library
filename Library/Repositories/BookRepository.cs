using Library.Data;
using Library.Models;
using System.Linq.Expressions;

namespace Library.Repositories
{
    internal class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        {
        }
        public LibraryContext dbContext { get { return _dbContext as LibraryContext; } }
        public void AddBook(Book book)
        {
            dbContext.books.Add(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return dbContext.books.ToList();
        }

        public Book GetBook(int Id)
        {
            return dbContext.books.Find(Id);
        }

        public void RemoveBook(Book book)
        {
            dbContext.books.Remove(book);
        }

        public IEnumerable<Book> FindBooks(Expression<Func<Book, bool>> predicate)
        {
            return dbContext.books.Where(predicate);
        }

        public void UpdateBook(Book book)
        {
            dbContext.books.Update(book);
        }
    }
}
