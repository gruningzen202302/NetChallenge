using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;
//using Microsoft.EntityFrameworkCore.Relational;//TODO check this error in Visual studio for Windows

namespace NetChallenge.Data{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            if (Database is null) Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //            modelBuilder.Entity<Location>()
            //                .HasKey(compositeKey => new { compositeKey.Id, compositeKey.Name });

            modelBuilder.Entity<Location>()
                .HasMany(location => location.Offices)
                .WithOne(office => office.Location)
                .HasForeignKey(office => office.LocationId);

            modelBuilder.Entity<Office>()
                .HasMany(office => office.Facilities)
                .WithOne(facility => facility.Office)
                .HasForeignKey(facility => facility.OfficeId);
            modelBuilder.Entity<Office>()
                .HasKey(o => new { o.Id, o.LocationId });

            modelBuilder.Entity<Facility>()
                .HasOne(facility => facility.Office)
                .WithMany(office => office.Facilities)
                .HasForeignKey(fk => new { fk.OfficeId, fk.LocationId });

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Office)
                .WithMany()
                .HasForeignKey(fk => new { fk.OfficeId, fk.LocationId })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite();

        IQueryable<Booking> IDbContext.Bookings => Set<Booking>();

        IQueryable<Facility> IDbContext.Facilities => Set<Facility>();

        IQueryable<Location> IDbContext.Locations => Set<Location>();

        IQueryable<Office> IDbContext.Offices => Set<Office>();

        IQueryable<User> IDbContext.Users => Set<User>();
    }
}