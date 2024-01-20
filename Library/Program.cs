using Library.Services;
using Library.Data;
using Library.Models;
using Library.Repositories;

//pass your connection string to LibraryContext constructor method
LibraryContext DbContext = new LibraryContext("Server=Mahdi;Database=Library;Integrated Security=True;");
UnitOfWork unitOfWork = new UnitOfWork(DbContext);
BookService bookService=new BookService(unitOfWork);

// Display menu options and handle user input
while (true)
{
    Console.Clear();
    Console.WriteLine("Library Management System");
    Console.WriteLine("1. Add a Book");
    Console.WriteLine("2. Edit a Book");
    Console.WriteLine("3. Delete a Book");
    Console.WriteLine("4. View All Books");
    Console.WriteLine("5. Search For Books");
    Console.WriteLine("6. Exit");


    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    Console.Clear();
    switch (choice)
    {
        case "1":
            {
                Book addingBook = new Book();
                BookService.ReadBookInfo(ref addingBook);
                unitOfWork.Book.AddBook(addingBook);
                Console.WriteLine("Book Added Successfully");
                break;
            }
        case "2":
            {

                bookService.ViewAllBooks();
                int Id = BookService.ReadId();
                Book updatedBook = new Book();
                updatedBook = unitOfWork.Book.GetBook(Id);
                BookService.PrintBookInfo(updatedBook);
                BookService.ReadBookInfo(ref updatedBook);
                unitOfWork.Book.UpdateBook(updatedBook);
                Console.WriteLine("Book Updated Successfully");
                break;
            }

        case "3":
            {
                bookService.ViewAllBooks();
                Book removingBook = new Book();
                int Id = BookService.ReadId();
                removingBook = unitOfWork.Book.GetBook(Id);
                unitOfWork.Book.RemoveBook(removingBook);
                Console.WriteLine("Book Deleted Successfully");
                break;
            }
        case "4":
            bookService.ViewAllBooks();
            break;
        case "5":
            Console.WriteLine("Enter a phrase to search it in Library: ");
            string searchKey = Console.ReadLine();
            bookService.SearchBooks( searchKey);
            break;
        case "6":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;

    }
    unitOfWork.Complete();

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}




