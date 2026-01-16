using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Library> Libraries { get; set; }
        public ICollection<Employee> Employees { get; set; }
        
    }
}
