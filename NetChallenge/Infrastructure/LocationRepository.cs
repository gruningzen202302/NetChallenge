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

        private List<Location> _context_Locations = new(){
            new(){
                Name="New York",
            },
            new(){
                Name="Mexico DF",
            }
        };
        private readonly IDbContext _context;
        public LocationRepository()
        {
            //context_Locations = new List<Location>();
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
            if (_context is null) { _context_Locations.Add(location); return; }

            _context.Locations.ToHashSet<Location>().Add(location);
        }

        public IEnumerable<Location> GetAllDeprecated()
        {

            if (_context is null) return _context_Locations.ToList();

            return _context.Locations.ToList();

        }

        public Location GetOne(Func<Location, bool> predicate)
        {
            Location location;

            if (_context is null)
            {
                location = _context_Locations.FirstOrDefault(predicate);
            }
            else
            {
                location = _context.Locations.FirstOrDefault(predicate);
            }
            if (location is null) throw new Exception("Location does not exist");

            return location;
        }

        public IEnumerable<Location> GetMany(Func<Location, bool> predicate)
        {
            IEnumerable<Location> locations = Enumerable.Empty<Location>();
            if (_context is null)
            {
                locations = _context_Locations.Where(predicate);
            }
            else
            {
                locations = _context.Locations.Where(predicate);
            }
            return locations;
        }
    }
}