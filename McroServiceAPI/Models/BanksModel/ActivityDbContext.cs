using Microsoft.EntityFrameworkCore;

namespace McroServiceAPI.Models.BanksModel
{
    public class ActivityDbContext : DbContext
    {
        public ActivityDbContext(DbContextOptions<ActivityDbContext> context) : base(context)
        {

        }

        public DbSet<Banks> Banks { get; set; }
    }
}
