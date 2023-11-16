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
        private List<Office> _context_Offices = new(){
            new(){
                Name="Soho",
                Location= new(){
                    Name="New York",
                }
            },
            new(){
                Name="Manhattan",
                Location= new(){
                    Name="New York",
                }
            }
        };
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
            Office office = null;
            //TODO replace with FirstOrDefault if the custom Exception implemented handles result >1 
            if (_context is null)
            {
                office = _context_Offices.FirstOrDefault(predicate);

            }
            else
            {
                office = _context.Offices.FirstOrDefault(predicate);
            }
            if (office is null) throw new Exception("This office does not exist");
            return office;
        }

        public IEnumerable<Office> GetSome(Func<Office, bool> predicate)
        {
            IEnumerable<Office> offices= Enumerable.Empty<Office>();
            if(_context is null){
                offices = _context_Offices.Where(predicate);
            } else {
                offices = _context.Offices.Where(predicate);
            }
            return offices;
        }
    }
}