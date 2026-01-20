namespace Biblioteka.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public required string Condition { get; set; }
        public bool Available { get; set; }

        public int BookId { get; set; }
        public required Book Book { get; set; }

        public int LibraryId { get; set; }
        public required Library Library { get; set; }

        public required ICollection<Rent> Rents { get; set; }
    }
}
