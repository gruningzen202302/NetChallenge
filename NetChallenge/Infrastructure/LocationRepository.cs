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

        private List<Location> context_Locations = new(){
            new(){
                Name="New York",
            },
            new(){
                Name="Mexico DF",
            }
        };
        private readonly AppDbContext _context;
        public LocationRepository()
        {
            //context_Locations = new List<Location>();
        }
        public LocationRepository(AppDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Location> AsEnumerable()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Location location)
        {
            if (_context is null) { context_Locations.Add(location); return; }

            _context.Locations.Add(location);
        }

        public IEnumerable<Location> GetAll()
        {

            if (_context is null) return context_Locations.ToList();

            return _context.Locations.ToList();

        }

        public Location GetOne(Func<Location, bool> predicate)
        {
            if(_context is null) return context_Locations.Single(predicate);
            return _context.Locations.Single(predicate) ;
        }
    }
}