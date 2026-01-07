namespace Biblioteka.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Open_Hours { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<BookCopy> BookCopies { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
