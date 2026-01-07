using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Biblioteka.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required, StringLength(150)]

        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Count { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BookCopy> Copies { get; set; }

    }
}
