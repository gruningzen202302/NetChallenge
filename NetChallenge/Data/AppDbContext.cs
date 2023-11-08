using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;

namespace NetChallenge.Data{
    public class AppDbContext:DbContext{
        public AppDbContext(){}
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){
            if (Database is null) Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)=>options.UseSqlite();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Office> Offices =>Set<Office>();
    }
}