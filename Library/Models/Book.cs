using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    internal class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int? Pages { get; set; }
        public Book()
        {

        }
    }
}
