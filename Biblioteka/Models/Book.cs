using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Biblioteka.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tytul jest wymagany")]
        [StringLength(200)]
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public int Count { get; set; }
        public int LibraryId { get; set; }
        public Library? Library { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<BookCopy>? Copies { get; set; }

    }
}
