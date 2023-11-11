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

        private List<Location> context_Locations = new();
        private readonly AppDbContext context;
        public LocationRepository()
        {
            //context_Locations = new List<Location>();
        }
        public LocationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Location> AsEnumerable()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Location location)
        {
            if (context is null) { context_Locations.Add(location); return; }

            context.Locations.Add(location);
        }

        public IEnumerable<Location> GetAll()
        {

            if (context is null) return context_Locations.ToList();

            return context.Locations.ToList();

        }

    }
}