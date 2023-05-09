namespace McroServiceAPI.Models.CustomersModel
{
    public class Customers
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
        public string? StateofResidence { get; set; }

        public string? LGA { get; set; }
        
    }
}
