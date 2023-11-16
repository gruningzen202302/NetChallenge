using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain;
using System.Linq;

namespace NetChallenge.Data
{
    public interface IDbContext
    {
        IQueryable<Booking> Bookings { get; set; }
        IQueryable<Facility> Facilities { get; set;}
        IQueryable<Location> Locations { get; set;}
        IQueryable<Office> Offices { get; set;}
        IQueryable<User> Users { get; set;}
    }
}