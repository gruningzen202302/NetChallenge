using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using NetChallenge.Abstractions;
using NetChallenge.Data;
using NetChallenge.Domain;

namespace NetChallenge.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IDbContext _context;
        public OfficeRepository()
        {
            _context = new MockContext();
        }
        public OfficeRepository(IDbContext context )
        {
            _context = context;
        }
        public IEnumerable<Office> GetAll() => _context.Offices;

        public void Add(Office office)
        {
            _context.Offices.ToList().Add(office);
        }

        public IEnumerable<Office> GetAllDeprecated() => new List<Office>();

        public void GetOne(Func<Office, bool> predicate)
        {
            throw new NotImplementedException();
        }

        Office IRepository<Office>.GetOne(Func<Office, bool> predicate)
        { 
            var ls = _context.Offices.ToList();
            var office = _context.Offices.FirstOrDefault(predicate);
            
            return office;
        }

        public IEnumerable<Office> GetMany(Func<Office, bool> predicate) => _context.Offices.ToList().Where(predicate);
    }
}