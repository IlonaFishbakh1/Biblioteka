namespace Biblioteka.Models
{
    public class Library
    {
        public int Id { get; set; }
        public required string Open_Hours { get; set; }
        public int AddressId { get; set; }
        public required Address Address { get; set; }
        public required ICollection<Book> Books { get; set; }
        public required ICollection<BookCopy> BookCopies { get; set; }
        public required ICollection<Employee> Employees { get; set; }
        public required ICollection<Rent> Rents { get; set; }
    }
}
