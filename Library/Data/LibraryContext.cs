using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    internal class LibraryContext: DbContext
    {
        private string _connectionString;
        public LibraryContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<Book> books { get; set; }
         
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {           
            contextOptionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
