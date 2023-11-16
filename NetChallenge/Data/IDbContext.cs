using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;
using System.Linq;

namespace NetChallenge.Data
{
    public interface IDbContext
    {
        //DbSet<Booking> Bookings { get; }
        //DbSet<Facility> Facilities { get; }
        //DbSet<Location> Locations { get; }
        //DbSet<Office> Offices { get; }
        //DbSet<User> Users { get; }

        IQueryable<Booking> Bookings { get; }
        IQueryable<Facility> Facilities { get; }
        IQueryable<Location> Locations { get; }
        IQueryable<Office> Offices { get; }
        IQueryable<User> Users { get; }
    }
}