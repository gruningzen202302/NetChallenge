using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;

namespace NetChallenge.Data{
    public class AppDbContext:DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Location> Locations => Set<Location>();
    }
}