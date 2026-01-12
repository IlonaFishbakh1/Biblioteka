using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Rent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Data wypozyczenia jest wymagana")]
        public DateTime Rent_Date { get; set; }
        public DateTime? Return_Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? EmpId { get; set; }
        public Employee? Employee { get; set; }
        public int? CopyId { get; set; }
        public BookCopy? BookCopy { get; set; }


        public int? LibraryId { get; set; }
        public Library? Library { get; set; }
    }
}