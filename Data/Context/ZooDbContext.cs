using Microsoft.EntityFrameworkCore;
using ZooApp_EF.Data.Entity;

namespace ZooApp_EF.Data.Context
{
    public class ZooDbContext:DbContext
    {
        public ZooDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Zoo> Zoos { get; set; }
    }
}
