using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string Emp_Name { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Emp_Surname { get; set; }
        public DateTime  Hire_Date { get; set; }
        public string Email { get; set; }
        public int? LibraryId { get; set; }
        public Library? Library { get; set; }

        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
