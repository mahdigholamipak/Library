using Library.Data;

namespace Library.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _dbContext;
        public UnitOfWork(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            Book = new BookRepository(_dbContext);
        }
        public IBookRepository Book { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
