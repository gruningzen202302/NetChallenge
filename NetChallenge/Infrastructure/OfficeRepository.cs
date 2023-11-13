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
        private List<Office> context_Offices = new(){
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
        private readonly AppDbContext _context;

        public OfficeRepository(AppDbContext context = null)
        {
            _context = context;
        }
        public IEnumerable<Office> AsEnumerable()=> _context.Offices;

        public void Add(Office item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Office> GetAll()=> new List<Office>();

        public void GetOne(Func<Office, bool> predicate)
        {
            throw new NotImplementedException();
        }

        Office IRepository<Office>.GetOne(Func<Office, bool> predicate)
        {
            if(_context is null) return context_Offices.Single(predicate);
            return _context.Offices.Single(predicate) ;
        }
    }
}