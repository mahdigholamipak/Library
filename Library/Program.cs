using Library.Services;
using Library.Data;
using Library.Models;

//pass your connection string to LibraryContext constructor method
LibraryContext DbContext = new LibraryContext("Server=Mahdi;Database=Library;Integrated Security=True;");
LibraryManager libraryManager = new LibraryManager(DbContext);

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
                libraryManager.AddBook(addingBook);
                break;
            }
        case "2":
            {
                libraryManager.ViewAllBooks();
                int Id = BookService.ReadId();
                Book updatedBook = new Book();
                updatedBook=libraryManager.getBookById(Id);
                BookService.PrintBookInfo(updatedBook);
                BookService.ReadBookInfo(ref updatedBook);
                libraryManager.UpdateBook(updatedBook);
                break;
            }
            
        case "3":
            {
                libraryManager.ViewAllBooks();
                Book removingBook = new Book();
                int Id = BookService.ReadId();
                removingBook=libraryManager.getBookById(Id);
                libraryManager.RemoveBook(removingBook);
                break;
            }
        case "4":
            libraryManager.ViewAllBooks();
            break;
        case "5":
            Console.WriteLine("Enter a phrase to search it in Library: ");
            string searchKey = Console.ReadLine();
            libraryManager.SearchBooks(searchKey);
            break;
        case "6":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;

    }


    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
