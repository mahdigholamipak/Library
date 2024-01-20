using Library.Models;
using Library.Repositories;

namespace Library.Services
{
    internal class BookService
    {
        private readonly UnitOfWork _unitOfWork;
        public BookService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public static void ReadBookInfo(ref Book book)
        {
            Console.WriteLine("Enter Book's name: ");
            book.Name = Console.ReadLine();
            Console.WriteLine("Enter Book Author's name: ");
            book.Author = Console.ReadLine();
            Console.WriteLine("Enter Book's number of pages: ");
            book.Pages = Convert.ToInt32(Console.ReadLine());
        }
        public static int ReadId()
        {
            Console.WriteLine("Enter Book's Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            return Id;
        }
        public static void PrintBookInfo(Book book)
        {
            Console.WriteLine($"Id: {book.Id}, Name: {book.Name}, Aothor: {book.Author}, Number of Pages: {book.Pages}");
        }

        public  void ViewAllBooks()
        {
            IEnumerable<Book> books = _unitOfWork.Book.GetAll();
            foreach (Book book in books)
            {
                PrintBookInfo(book);
            }
        }
        public  void SearchBooks( string SearchKey)
        {
            IEnumerable<Book> books = _unitOfWork.Book.Find(book => book.Name.Contains(SearchKey));
            foreach (Book book in books)
            {
                PrintBookInfo(book);
            }
        }
    }
}
