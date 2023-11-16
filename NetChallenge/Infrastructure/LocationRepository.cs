using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;

namespace NetChallenge.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {

        private readonly IDbContext _context;
        public LocationRepository()
        {
            _context = new MockContext();
        }
        public LocationRepository(IDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Location> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Location location)
        {
            _context.Locations.ToHashSet<Location>().Add(location);
        }

        public IEnumerable<Location> GetAllDeprecated()
        {
            throw new NotSupportedException($"This method is deprecated");
        }

        public Location GetOne(Func<Location, bool> predicate) => _context.Locations.FirstOrDefault(predicate);

        public IEnumerable<Location> GetMany(Func<Location, bool> predicate) => _context.Locations.Where(predicate);
    }
}