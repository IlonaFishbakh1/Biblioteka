using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Imie jest wymagane")]
        public required string Emp_Name { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public required string Emp_Surname { get; set; }
        public DateTime  Hire_Date { get; set; }
        public required string Email { get; set; }
        public int? LibraryId { get; set; }
        public Library? Library { get; set; }

        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public required ICollection<Rent> Rents { get; set; }
    }
}
