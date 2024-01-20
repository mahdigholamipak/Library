using Library.Models;

namespace Library.Services
{
    internal class BookService
    {
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
        
        
    }
}
