namespace Biblioteka.Models
{
    public class User
    {
        public int Id { get; set; }
        public string U_Name { get; set; }
        public string U_Surname { get; set; }
        public int Book_Limit { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
