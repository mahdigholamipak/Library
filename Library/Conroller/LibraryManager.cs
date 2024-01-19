using Library.Data;
using Library.Models;

namespace Library.Conroller
{
    internal class LibraryManager
    {
        static LibraryContext DbContext = new LibraryContext();

        internal static  void AddBook()
        {
            Console.Clear();
            Book addingBook = new Book();
            Console.WriteLine("Enter Book's name: ");
            addingBook.Name =Console.ReadLine();
            Console.WriteLine("Enter Book Author's name: ");
            addingBook.Author = Console.ReadLine();
            Console.WriteLine("Enter Book's number of pages: ");
            addingBook.Pages =Convert.ToInt32( Console.ReadLine());
            DbContext.books.Add(addingBook);
            DbContext.SaveChanges();
            Console.WriteLine("Book added Successfully");         
        }
        internal static void RemoveBook()
        {
            Console.Clear();
            ViewAllBooks();
            Console.WriteLine("Enter Book's Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Book removingBook = (from book in DbContext.books where book.Id == Id select book).First();
            DbContext.books.Remove(removingBook);
            DbContext.SaveChanges();
            Console.WriteLine("Book removed Successfully");
        }
        internal static void UpdateBook()
        {
            Console.Clear();
            ViewAllBooks();
            Console.WriteLine("Enter Book's Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Book updatingBook = (from book in DbContext.books where book.Id == Id select book).First();  
            Console.WriteLine($"Id: {updatingBook.Id}, Name: {updatingBook.Name}, Aothor: {updatingBook.Author}");
            Console.WriteLine("Enter Book's name: ");
            updatingBook.Name = Console.ReadLine();
            Console.WriteLine("Enter Book Author's name: ");
            updatingBook.Author = Console.ReadLine();
            Console.WriteLine("Enter Book's number of pages: ");
            updatingBook.Pages = Convert.ToInt32(Console.ReadLine());
            DbContext.books.Update(updatingBook);
            DbContext.SaveChanges();
            Console.WriteLine("Book updated Successfully");         
        }
        internal static void ViewAllBooks()
        {
            Console.Clear();
            IEnumerable<Book> books = from book in DbContext.books select book;           
            foreach (Book book in books)
            {
                Console.WriteLine($"Id: {book.Id}, Name: {book.Name}, Aothor: {book.Author}");
            }
        }
        internal static void SearchBooks()
        {
            Console.Clear();

            Console.WriteLine("Enter a phrase to search it in Library: ");
            string searchKey = Console.ReadLine();
            IEnumerable<Book> books = from book in DbContext.books where book.Name.Contains(searchKey) select book;        
            foreach (Book book in books)
            {
                Console.WriteLine($"Id: {book.Id}, Name: {book.Name}, Aothor: {book.Author}");
            }
        }
    }
}
