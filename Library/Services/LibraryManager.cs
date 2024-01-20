using Library.Data;
using Library.Models;

namespace Library.Services
{
    internal class LibraryManager
    {
        private LibraryContext _dbContext;
        public LibraryManager(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBook(Book addingBook)
        {
            _dbContext.books.Add(addingBook);
            _dbContext.SaveChanges();
            Console.WriteLine("Book added Successfully");
        }
        public void UpdateBook(Book updatedBook)
        {
            _dbContext.books.Update(updatedBook);
            _dbContext.SaveChanges();
            Console.WriteLine("Book updated Successfully");
        }
        public void RemoveBook(Book removingBook)
        {          
            _dbContext.books.Remove(removingBook);
            _dbContext.SaveChanges();
            Console.WriteLine("Book removed Successfully");
        }
        public void ViewAllBooks()
        {
            IEnumerable<Book> allBooks = from book in _dbContext.books select book;
            foreach (Book book in allBooks)
            {
                BookService.PrintBookInfo(book);
            }
        }
        public void SearchBooks(string searchKey)
        {          
            IEnumerable<Book> searchedBooks = from book in _dbContext.books where book.Name.Contains(searchKey) select book;
            foreach (Book book in searchedBooks)
            {
                BookService.PrintBookInfo(book);
            }
        }
        public Book getBookById(int Id)
        {
            Book book = (from bookElement in _dbContext.books where bookElement.Id == Id select bookElement).First();
            return book;
        }
    }
}
