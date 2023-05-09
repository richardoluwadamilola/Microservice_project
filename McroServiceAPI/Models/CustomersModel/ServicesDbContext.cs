using Microsoft.EntityFrameworkCore;

namespace McroServiceAPI.Models.CustomersModel
{
    public class ServicesDbContext : DbContext
    {
        public ServicesDbContext(DbContextOptions<ServicesDbContext> context) : base(context)
        {

        }

        public DbSet<Customers> Customers { get; set; }
       
    }
}
