using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;
//using Microsoft.EntityFrameworkCore.Relational;//TODO check this error in Visual studio for Windows

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
            .HasForeignKey(office=> office.LocationId);

            modelBuilder.Entity<Office>()
                .HasMany(office => office.Facilities)
                .WithOne(facility => facility.Office)
                .HasForeignKey(facility => facility.OfficeId);
            modelBuilder.Entity<Office>()
                .HasKey(o => new { o.Id, o.LocationId });
            
            modelBuilder.Entity<Facility>()
                .HasOne(facility => facility.Office)
                .WithMany(office => office.Facilities)
                .HasForeignKey(facility => new { facility.OfficeId, facility.LocationId });
            
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Office)
                .WithMany()
                .HasForeignKey("OfficeId")
                .OnDelete(DeleteBehavior.Restrict); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)=>options.UseSqlite();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Office> Offices =>Set<Office>();
        public DbSet<Facility> Facilities => Set<Facility>();
        public DbSet<Booking> Bookings => Set<Booking>();
    }
}