namespace Biblioteka.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public string Condition { get; set; }
        public bool Available { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int LibraryId { get; set; }
        public Library Library { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
