First of all go to "Library/Data/LibraryContext.cs" File and then in OnConfiguring method pass your connection string to  contextOptionsBuilder.UseSqlServer() method call.
![image](https://github.com/mahdigholamipak/Library/assets/80640317/1497fe57-a1b4-4b41-878b-86ec4b381484)

then in Package Manager Console enter Update-Database command.
