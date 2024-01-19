using Library.Conroller;


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

    switch (choice)
    {
        case "1":
            LibraryManager.AddBook();
            break;
        case "2":
            LibraryManager.UpdateBook();
            break;
        case "3":
            LibraryManager.RemoveBook();
            break;
        case "4":
            LibraryManager.ViewAllBooks();
            break;
        case "5":
            LibraryManager.SearchBooks();
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
