using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;

namespace NetChallenge.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext context;
        public LocationRepository(){}
        public LocationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Location> AsEnumerable()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Location item)
        {
            context.Locations.Add(item);
            context.SaveChanges();
        }
    }
}