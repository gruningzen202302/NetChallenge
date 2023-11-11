using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;

namespace NetChallenge.Data{
    public class AppDbContext:DbContext{
        public AppDbContext(){}
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){
            if (Database is null) Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>()
            .HasMany(location=>location.Offices)
            .WithOne(office=>office.Location)
            .HasForeignKey(office=> office.LocationId)
            ;

            modelBuilder.Entity<Office>()
                .HasMany(office => office.AvailableResources)
                .WithOne(availableResource => availableResource.Office)
                .HasForeignKey(availableResource => availableResource.OfficeId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)=>options.UseSqlite();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Office> Offices =>Set<Office>();
        public DbSet<AvailableResource> AvailableResources => Set<AvailableResource>();
    }
}