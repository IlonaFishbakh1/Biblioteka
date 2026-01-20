using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public required string AddressLine { get; set; }
        public required string City { get; set; }
        public required string Zipcode { get; set; }
        public required ICollection<Library> Libraries { get; set; }
        public required ICollection<Employee> Employees { get; set; }
        
    }
}
