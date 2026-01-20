namespace Biblioteka.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<Book> Books { get; set; }
    }
}
