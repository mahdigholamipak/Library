using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    internal class LibraryContext: DbContext
    {
        public DbSet<Book> books { get; set; }
         
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            //pass your connection string to UseSqlServer method
            contextOptionsBuilder.UseSqlServer("Server=Mahdi;Database=Library;Integrated Security=True;");
        }
    }
}
